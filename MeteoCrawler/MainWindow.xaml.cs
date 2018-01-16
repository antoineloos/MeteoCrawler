using HtmlAgilityPack;
using System;
using ScrapySharp.Extensions;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using System.Text.RegularExpressions;
using ScrapySharp.Network;

namespace MeteoCrawler
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Regex reg5;
        public MutuelleBDEntities ctx { get; set; }
      
        int totalcmpt = 0;
        public List<Station2> lstStation { get; set; }

        Dictionary<string, string> lstmois { get; set; }
        List<int> lstannee { get; set; }
        public MainWindow()
        {
            InitializeComponent();
           
            ctx = new MutuelleBDEntities();
            lstStation = ctx.Station2.ToList();
            lstmois = new Dictionary<string, string>();
            lstannee = new List<int>();
            reg5 = new Regex(@"(\.\d)?(\-?\d?\d.\d)(\&deg\;C)");

        }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            

           

            HtmlAgilityPack.HtmlNode.ElementsFlags.Remove("option");
            var baseUrl = @"https://www.infoclimat.fr/observations-meteo/temps-reel/agde/00069.html";
            var baseUrl2 = @"https://www.infoclimat.fr/climatologie-mensuelle/";

            ScrapySharp.Network.ScrapingBrowser browser = new ScrapySharp.Network.ScrapingBrowser();
            var res = await browser.NavigateToPageAsync(new Uri(baseUrl));
            var sele = res.Html.CssSelect("#select_station");
            var nbvi = sele.First().ChildNodes.Count;
            long moytimepercity = 1;
            List<int> lstannee = new List<int>();

            lstannee.Add(2009);
            lstannee.Add(2010);
            lstannee.Add(2011);
            lstannee.Add(2012);
            lstannee.Add(2013);

            Dictionary<string, string> lstmois = new Dictionary<string, string>();
            lstmois.Add("01", "janvier");
            lstmois.Add("02", "fevrier");
            lstmois.Add("03", "mars");
            lstmois.Add("04", "avril");
            lstmois.Add("05", "mai");
            lstmois.Add("06", "juin");
            lstmois.Add("07", "juillet");
            lstmois.Add("08", "aout");
            lstmois.Add("09", "septembre");
            lstmois.Add("10", "octobre");
            lstmois.Add("11", "novembre");
            lstmois.Add("12", "decembre");


            foreach (int annee in lstannee)
            {
                var spendedtime = System.Diagnostics.Stopwatch.StartNew();

                foreach (KeyValuePair<string, string> mois in lstmois)
                {

                    anneetxt.Text = annee.ToString() + "/";
                    moistxt.Text = mois.Value;
                    var suffix = "/" + mois.Value + "/" + annee.ToString() + "/agde-le-grau.html";
                    var cmpt = 0;
                    foreach (HtmlAgilityPack.HtmlNode prod in sele.First().ChildNodes)
                    {
                        

                        nbville.Text = nbvi.ToString();
                        nbcurrent.Text = cmpt.ToString();
                        foreach (HtmlAttribute elem in prod.Attributes)
                        {
                            var timepercity = System.Diagnostics.Stopwatch.StartNew();
                            
                            if (elem.Name == "value" && !String.IsNullOrEmpty(elem.Value) )
                            {


                                try
                                {
                                    var result = await browser.NavigateToPageAsync(new Uri(baseUrl2 + elem.Value + suffix));
                                


                                foreach (HtmlNode day in result.Html.CssSelect(".climday"))
                                {
                                    Meteo rec = new Meteo();
                                    rec.idMesure = 0;
                                    rec.date = DateTime.Parse(annee.ToString() + "-" + mois.Key + "-" + day.InnerText);
                                    rec.station = prod.InnerText;
                                    var mes = day.ParentNode.ParentNode.ParentNode.ChildNodes.CssSelect(".named-units");
                                    if (mes.Count() > 0)
                                    {
                                        var tmp = mes.Where(n => n.InnerText != null && n.InnerText == "&deg;C");
                                  
                                        if (tmp.Count() == 2)
                                        {
                                     

                                            var mtch = reg5.Match(tmp.First().ParentNode.InnerText);
                                            if (mtch.Groups.Count > 1)
                                            {
                                                rec.tempmin = float.Parse(mtch.Groups[2].Value.Replace('.', ','));
                                            }
                                            else Debug.WriteLine(tmp.First().ParentNode.InnerText);
                                            var mtch2 = reg5.Match(tmp.Last().ParentNode.InnerText);
                                            if (mtch2.Groups.Count > 1)
                                            {
                                                rec.tempmax = float.Parse(mtch2.Groups[2].Value.Replace('.', ','));
                                            }
                                            else Debug.WriteLine(tmp.Last().ParentNode.InnerText);
                                        }
                                        var pl = mes.Where(n => n.InnerText != null && n.InnerText == "mm");
                                        if (pl.Count() > 0)
                                        {
                                            rec.precipe = float.Parse(pl.First().ParentNode.InnerText.Replace("mm", "").Replace('.', ','));
                                            // Debug.WriteLine(float.Parse(pl.First().ParentNode.InnerText.Replace("mm", "").Replace('.', ',')).ToString());
                                        }
                                        var vt = mes.Where(n => n.InnerText != null && n.InnerText == " km/h");
                                        if (vt.Count() > 0)
                                        {
                                            rec.ventmax = float.Parse(vt.First().ParentNode.InnerText.Replace(" km/h", "").Replace('.', ','));
                                            // Debug.WriteLine(float.Parse(vt.First().ParentNode.InnerText.Replace(" km/h", "").Replace('.', ',')).ToString());
                                        }



                                        if (rec.date != null && rec.station != null && (rec.tempmax != null || rec.tempmin != null)) ctx.Meteo.Add(rec);



                                    }



                                }
                                }
                                catch { }
                                
                                totalcmpt += ctx.SaveChanges();
                                Debug.WriteLine("nb records saved : " + totalcmpt);

                                cmpt++;
                            }


                        }

                        spendedtime.Stop();
                    }
                    
                }
            }
            MessageBox.Show("Done ! total record saved :" + totalcmpt);
        }
    }
}
