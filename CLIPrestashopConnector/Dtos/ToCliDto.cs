using System;
using CLIPrestashopConnector.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CLIPrestashopConnector.Dtos
{
    public class ToCliDto
    {
        public long Id { get; set; } 
        public long Id_T_Famille { get; set; } 
        public string Reference { get; set; } 
        public bool Force { get; set; } = false;
        public bool AssociatedAddress { get; set; } = false;
        public bool AssociatedCartRule { get; set; } = false;
        public bool AssociatedLegacyImages { get; set; } = false;
        public string Image { get; set; } = string.Empty;
        public long DefaultImageId { get; set; } 
        public byte[] FactureData { get; set; }
        public bool OnlyErrors { get; set; } = false;
        public bool OnlyNewSync { get; set; } = false;
        public bool ImportStock { get; set; } = false;
        public bool DeleteBeforeImport { get; set; } = false;
        public DateTime? UpdatedDateFrom { get; set; } = null;
        public List<long> ToDeleteImages { get; set; }
        public List<ImageData> ToAddImages { get; set; }
        public int Number { get; set; } = 0;
        // pour gérer les produits en masse
        public List<long> Ids { get; set; }
            public string CurrentMessage { get; set; }= string.Empty;
    public string NewMessage { get; set; }= string.Empty;
        public ToCliDto()
        {
            ToDeleteImages = new List<long>();
            ToAddImages = new List<ImageData>();
            Ids = new List<long>();
        }
    }
}

