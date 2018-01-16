using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteoCrawler
{
    class _old
    {
    }
    
        //private async void Button_Click(object sender, RoutedEventArgs e)
        //{

        //    HtmlAgilityPack.HtmlNode.ElementsFlags.Remove("option");
        //    var baseUrl = @"https://www.infoclimat.fr/observations-meteo/temps-reel/agde/00069.html";
        //    var baseUrl2 = @"https://www.infoclimat.fr/climatologie-mensuelle/";

        //    ScrapySharp.Network.ScrapingBrowser browser = new ScrapySharp.Network.ScrapingBrowser();





        //    foreach (int annee in lstannee)
        //    {


        //        foreach (KeyValuePair<string, string> mois in lstmois)
        //        {

        //            anneetxt.Text = annee.ToString() + "/";
        //            moistxt.Text = mois.Value;

        //            var suffix = "/" + mois.Value + "/" + annee.ToString() + "/agde-le-grau.html";
        //            var cmpt = 0;

        //            foreach (LstDep dep in ctx.LstDep.ToList())
        //            {
        //                deptxt.Text = dep.departement;
        //                bool IsRecContainNull = false;
                        
        //                while (!IsRecContainNull && cmpt<ctx.Station2.ToList().Where(s => s.departement == dep.departement).Count())
        //                {
                            
        //                    var currentstation = ctx.Station2.ToList().Where(s => s.departement == dep.departement).ElementAt(cmpt);


                            
        //                    try
        //                    {

        //                        var result = await browser.NavigateToPageAsync(new Uri(baseUrl2 + currentstation.code + suffix));
                            
                            

        //                        foreach (HtmlNode day in result.Html.CssSelect(".climday"))
        //                        {
        //                            Meteo2 rec = new Meteo2();
        //                            rec.idMesure = 0;
        //                            rec.date = DateTime.Parse(annee.ToString() + "-" + mois.Key + "-" + day.InnerText);
        //                            rec.idStation = currentstation.idStation;
        //                            var mes = day.ParentNode.ParentNode.ParentNode.ChildNodes.CssSelect(".named-units");
        //                            if (mes.Count() > 0)
        //                            {
        //                                var tmp = mes.Where(n => n.InnerText != null && n.InnerText == "&deg;C");
        //                                if (tmp.Count() == 2)
        //                                {
        //                                    if (tmp.Any() && !string.IsNullOrEmpty(tmp.First().ParentNode.InnerText) ) 
        //                                    {
                                               
        //                                        var s = tmp.First().ParentNode.InnerText.Replace("&deg;C", "").Replace('.', ',');
        //                                        if (s.Split(',').Count() > 2) 
        //                                        {
        //                                            int index = s.IndexOf(',', s.IndexOf(',') + 1);
        //                                            s = s.Substring(0, index);
                                                    
        //                                        }
        //                                        if (s.Split('-').Count() > 2)
        //                                        {
        //                                            int index = s.IndexOf('-', s.IndexOf('-') + 1);
        //                                            s = s.Substring(0, index);
        //                                        }
                                                
        //                                        rec.tempmin = float.Parse(s);
        //                                    }

        //                                    if (tmp.Any() && !string.IsNullOrEmpty(tmp.First().ParentNode.InnerText))
        //                                    {
        //                                        var s = tmp.First().ParentNode.InnerText.Replace("&deg;C", "").Replace('.', ',');
        //                                        if (s.Split(',').Count() > 2)
        //                                        {
        //                                            int index = s.IndexOf(',', s.IndexOf(',') + 1);
        //                                            s = s.Substring(0, index);
        //                                        }
        //                                        if (s.Split('-').Count() > 2)
        //                                        {
        //                                            int index = s.IndexOf('-', s.IndexOf('-') + 1);
        //                                            s = s.Substring(0, index);
        //                                        }
        //                                        rec.tempmax = float.Parse(s);
        //                                    }

        //                                }
        //                                var pl = mes.Where(n => n.InnerText != null && n.InnerText == "mm");
        //                                if (pl.Count() > 0)
        //                                {
        //                                    if (tmp.Any() && !string.IsNullOrEmpty(tmp.First().ParentNode.InnerText)) rec.precipe = float.Parse(pl.First().ParentNode.InnerText.Replace("mm", "").Replace('.', ','));

        //                                }
        //                                var vt = mes.Where(n => n.InnerText != null && n.InnerText == " km/h");
        //                                if (vt.Count() > 0)
        //                                {
        //                                    if (tmp.Any() && !string.IsNullOrEmpty(tmp.First().ParentNode.InnerText)) rec.ventmax = float.Parse(vt.First().ParentNode.InnerText.Replace(" km/h", "").Replace('.', ','));

        //                                }



        //                                if (rec.date != null && rec.idStation != null && (rec.tempmax != null || rec.tempmin != null))
        //                                {
        //                                    ctx.Meteo2.Add(rec);
        //                                    IsRecContainNull = true;
        //                                }



        //                            }



        //                        }
        //                    }
        //                    catch (Exception ex) { }
        //                        cmpt++;

        //                    }
                      
        //                }



        //                ctx.SaveChanges();


        //            }


        //        }



        //        MessageBox.Show("Done ! ");
        //    }
        //}
    //private async void Button_Click(object sender, RoutedEventArgs e)
    //{

    //    HtmlAgilityPack.HtmlNode.ElementsFlags.Remove("option");
    //    var baseUrl = @"https://www.infoclimat.fr/observations-meteo/temps-reel/agde/00069.html";
    //    var baseUrl2 = @"https://www.infoclimat.fr/climatologie-mensuelle/";

    //    ScrapySharp.Network.ScrapingBrowser browser = new ScrapySharp.Network.ScrapingBrowser();
    //    var res = await browser.NavigateToPageAsync(new Uri(baseUrl));
    //    var sele = res.Html.CssSelect("#select_station");
    //    Regex regex = new Regex(@"(.*)\s\((\w\w)\)");
    //        foreach (HtmlAgilityPack.HtmlNode prod in sele.First().ChildNodes)
    //        {



    //            if(!String.IsNullOrEmpty(prod.InnerHtml))
    //            {
    //                Station2 st = new Station2();
    //                st.idStation = 0;
    //                Debug.WriteLine(prod.InnerText);
    //            Match match = regex.Match(prod.InnerText);
    //            if (match.Success)
    //            {
    //                st.nom = match.Groups[1].Value;
    //                st.departement = match.Groups[2].Value;
    //            }




    //            foreach (HtmlAttribute elem in prod.Attributes)
    //            {

    //                if (elem.Name == "value" && !String.IsNullOrEmpty(elem.Value))
    //                {
    //                    try
    //                    {
    //                        st.code = elem.Value;

    //                    }
    //                    catch (Exception ex) 
    //                    {
    //                        Debug.WriteLine(ex.Message);
    //                    }
    //                }

    //            }

    //          if(st.code != null && st.departement!=null && st.idStation !=null && st.nom!=null )  ctx.Station2.Add(st);


    //            }


    //        }
    //        try
    //        {
    //            ctx.SaveChanges();
    //        }
    //        catch (System.Data.Entity.Validation.DbEntityValidationException ex)
    //        {
    //            Debug.WriteLine(ex.Message);
    //        }
    //        MessageBox.Show("Done");

    //    }


    //    }

    //}



    //private async void Button_Click(object sender, RoutedEventArgs e)
    //{

    //    HtmlAgilityPack.HtmlNode.ElementsFlags.Remove("option");
    //    var baseUrl = @"https://www.infoclimat.fr/observations-meteo/temps-reel/agde/00069.html";
    //    var baseUrl2 = @"https://www.infoclimat.fr/climatologie-mensuelle/";

    //    ScrapySharp.Network.ScrapingBrowser browser = new ScrapySharp.Network.ScrapingBrowser();
    //    var res = await browser.NavigateToPageAsync(new Uri(baseUrl));
    //    var sele = res.Html.CssSelect("#select_station");
    //    var nbvi = sele.First().ChildNodes.Count;
    //    long moytimepercity = 1;
    //    List<int> lstannee = new List<int>();

    //    //lstannee.Add(2009);
    //    //lstannee.Add(2010);
    //    lstannee.Add(2011);
    //    lstannee.Add(2012);

    //    Dictionary<string, string> lstmois = new Dictionary<string, string>();
    //    lstmois.Add("01", "janvier");
    //    lstmois.Add("02", "fevrier");
    //    lstmois.Add("03", "mars");
    //    lstmois.Add("04", "avril");
    //    lstmois.Add("05", "mai");
    //    lstmois.Add("06", "juin");
    //    lstmois.Add("07", "juillet");
    //    lstmois.Add("08", "aout");
    //    lstmois.Add("09", "septembre");
    //    lstmois.Add("10", "octobre");
    //    lstmois.Add("11", "novembre");
    //    lstmois.Add("12", "decembre");


    //    foreach (int annee in lstannee)
    //    {
    //        var spendedtime = System.Diagnostics.Stopwatch.StartNew();

    //        foreach (KeyValuePair<string, string> mois in lstmois)
    //        {

    //            anneetxt.Text = annee.ToString() + "/";
    //            moistxt.Text = mois.Value;
    //            var suffix = "/" + mois.Value + "/" + annee.ToString() + "/agde-le-grau.html";
    //            var cmpt = 0;
    //            foreach (HtmlAgilityPack.HtmlNode prod in sele.First().ChildNodes)
    //            {
    //                Debug.WriteLine("\n" + prod.InnerText + "\n");

    //                nbville.Text = nbvi.ToString();
    //                nbcurrent.Text = cmpt.ToString();
    //                foreach (HtmlAttribute elem in prod.Attributes)
    //                {
    //                    var timepercity = System.Diagnostics.Stopwatch.StartNew();
    //                    if (elem.Name == "value" && !String.IsNullOrEmpty(elem.Value))
    //                    {
    //                        try
    //                        {
    //                            pgrbar.Minimum = 0;
    //                            pgrbar.Value = spendedtime.ElapsedMilliseconds;
    //                            pgrbar.Maximum = moytimepercity * nbvi * 24;

    //                            var result = await browser.NavigateToPageAsync(new Uri(baseUrl2 + elem.Value + suffix));



    //                            foreach (HtmlNode day in result.Html.CssSelect(".climday"))
    //                            {
    //                                Meteo rec = new Meteo();
    //                                rec.idMesure = 0;
    //                                rec.date = DateTime.Parse(annee.ToString() + "-" + mois.Key + "-" + day.InnerText);
    //                                rec.station = prod.InnerText;
    //                                var mes = day.ParentNode.ParentNode.ParentNode.ChildNodes.CssSelect(".named-units");
    //                                if (mes.Count() > 0)
    //                                {
    //                                    var tmp = mes.Where(n => n.InnerText != null && n.InnerText == "&deg;C");
    //                                    if (tmp.Count() == 2)
    //                                    {
    //                                        // Debug.WriteLine(float.Parse(tmp.First().ParentNode.InnerText.Replace("&deg;C", "").Replace('.', ',')).ToString());
    //                                        rec.tempmin = float.Parse(tmp.First().ParentNode.InnerText.Replace("&deg;C", "").Replace('.', ','));
    //                                        //  Debug.WriteLine(float.Parse(tmp.Last().ParentNode.InnerText.Replace("&deg;C", "").Replace('.', ',')).ToString());
    //                                        rec.tempmax = float.Parse(tmp.Last().ParentNode.InnerText.Replace("&deg;C", "").Replace('.', ','));

    //                                    }
    //                                    var pl = mes.Where(n => n.InnerText != null && n.InnerText == "mm");
    //                                    if (pl.Count() > 0)
    //                                    {
    //                                        rec.precipe = float.Parse(pl.First().ParentNode.InnerText.Replace("mm", "").Replace('.', ','));
    //                                        //Debug.WriteLine(float.Parse(pl.First().ParentNode.InnerText.Replace("mm", "").Replace('.', ',')).ToString());
    //                                    }
    //                                    var vt = mes.Where(n => n.InnerText != null && n.InnerText == " km/h");
    //                                    if (vt.Count() > 0)
    //                                    {
    //                                        rec.ventmax = float.Parse(vt.First().ParentNode.InnerText.Replace(" km/h", "").Replace('.', ','));
    //                                        //Debug.WriteLine(float.Parse(vt.First().ParentNode.InnerText.Replace(" km/h", "").Replace('.', ',')).ToString());
    //                                    }



    //                                    if (rec.date != null && rec.station != null && (rec.tempmax != null || rec.tempmin != null)) ctx.Meteo.Add(rec);



    //                                }



    //                            }
    //                            moytimepercity = timepercity.ElapsedMilliseconds;
    //                            timepercity.Reset();
    //                        }
    //                        catch (Exception ex) { }
    //                    }

    //                }
    //                ctx.SaveChanges();

    //                cmpt++;
    //            }


    //        }

    //        spendedtime.Stop();
    //    }
    //    MessageBox.Show("Done ! ");
    //}

      //HtmlAgilityPack.HtmlNode.ElementsFlags.Remove("option");
      //      var baseUrl = @"https://www.infoclimat.fr/observations-meteo/temps-reel/agde/00069.html";
      //      var baseUrl2 = @"https://www.infoclimat.fr/climatologie-mensuelle/";

      //      ScrapySharp.Network.ScrapingBrowser browser = new ScrapySharp.Network.ScrapingBrowser();
           
            


      //      foreach (int annee in lstannee)
      //      {
                

      //          foreach (KeyValuePair<string, string> mois in lstmois)
      //          {

      //              anneetxt.Text = annee.ToString() + "/";
      //              moistxt.Text = mois.Value;
      //              var suffix = "/" + mois.Value + "/" + annee.ToString() + "/agde-le-grau.html";
      //              var cmpt = 0;
      //              foreach (Station2 prod in ctx.Station2.ToList().Where(s=>s.departement == "16"))
      //              {
                      
      //                          try
      //                          {
                                  

      //                              var result = await browser.NavigateToPageAsync(new Uri(baseUrl2 + prod.code + suffix));



      //                              foreach (HtmlNode day in result.Html.CssSelect(".climday"))
      //                              {
      //                                  Meteo rec = new Meteo();
      //                                  rec.idMesure = 0;
      //                                  rec.date = DateTime.Parse(annee.ToString() + "-" + mois.Key + "-" + day.InnerText);
      //                                  rec.station = prod.nom;
      //                                  var mes = day.ParentNode.ParentNode.ParentNode.ChildNodes.CssSelect(".named-units");
      //                                  if (mes.Count() > 0)
      //                                  {
      //                                      var tmp = mes.Where(n => n.InnerText != null && n.InnerText == "&deg;C");
      //                                      if (tmp.Count() == 2)
      //                                      {
      //                                          // Debug.WriteLine(float.Parse(tmp.First().ParentNode.InnerText.Replace("&deg;C", "").Replace('.', ',')).ToString());
      //                                          rec.tempmin = float.Parse(tmp.First().ParentNode.InnerText.Replace("&deg;C", "").Replace('.', ','));
      //                                          //  Debug.WriteLine(float.Parse(tmp.Last().ParentNode.InnerText.Replace("&deg;C", "").Replace('.', ',')).ToString());
      //                                          rec.tempmax = float.Parse(tmp.Last().ParentNode.InnerText.Replace("&deg;C", "").Replace('.', ','));

      //                                      }
      //                                      var pl = mes.Where(n => n.InnerText != null && n.InnerText == "mm");
      //                                      if (pl.Count() > 0)
      //                                      {
      //                                          rec.precipe = float.Parse(pl.First().ParentNode.InnerText.Replace("mm", "").Replace('.', ','));
      //                                          //Debug.WriteLine(float.Parse(pl.First().ParentNode.InnerText.Replace("mm", "").Replace('.', ',')).ToString());
      //                                      }
      //                                      var vt = mes.Where(n => n.InnerText != null && n.InnerText == " km/h");
      //                                      if (vt.Count() > 0)
      //                                      {
      //                                          rec.ventmax = float.Parse(vt.First().ParentNode.InnerText.Replace(" km/h", "").Replace('.', ','));
      //                                          //Debug.WriteLine(float.Parse(vt.First().ParentNode.InnerText.Replace(" km/h", "").Replace('.', ',')).ToString());
      //                                      }



      //                                      if (rec.date != null && rec.station != null && (rec.tempmax != null || rec.tempmin != null)) ctx.Meteo.Add(rec);



      //                                  }



      //                              }
                                 
      //                          }
      //                          catch (Exception ex) { }
                            
      //                  ctx.SaveChanges();

      //                  cmpt++;
      //              }


      //          }

      //      }
      //      MessageBox.Show("Done ! ");
      //  }

}
