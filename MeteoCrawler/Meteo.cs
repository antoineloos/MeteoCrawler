//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MeteoCrawler
{
    using System;
    using System.Collections.Generic;
    
    public partial class Meteo
    {
        public int idMesure { get; set; }
        public string station { get; set; }
        public System.DateTime date { get; set; }
        public Nullable<double> tempmin { get; set; }
        public Nullable<double> tempmax { get; set; }
        public Nullable<double> ventmax { get; set; }
        public Nullable<double> precipe { get; set; }
    }
}