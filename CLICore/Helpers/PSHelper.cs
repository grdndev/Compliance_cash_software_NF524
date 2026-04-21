using System;
using System.Drawing;
using Bukimedia.PrestaSharp.Entities;
using Bukimedia.PrestaSharp.Factories;
using CLICore.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Dynamic;
using Microsoft.EntityFrameworkCore.DynamicLinq;
using System.Linq.Dynamic.Core;
using System.Linq;

namespace CLICore.Helpers
{
    
    public class PSHelper
    {

        const int PasswordSizeMin = 5;
        const int PasswordSizeMax = 72;

        public PSHelper()
        {

        }
        /// <summary>
        /// Permet de vérifier la validité du mot de passe (longeur uniquement)
        /// </summary>
        /// <param name="plaintextPasswd"></param>
        /// <returns></returns>
        public static bool isPlaintextPassword(string plaintextPasswd)
        {
            return plaintextPasswd.Length >= PasswordSizeMin && plaintextPasswd.Length <= PasswordSizeMax;
        }

        public static List<Bukimedia.PrestaSharp.Entities.AuxEntities.language> PSChampMultiLangue(string libelle, long idLang = 1)
        {
            var languages = new List<Bukimedia.PrestaSharp.Entities.AuxEntities.language>();
            var language = new Bukimedia.PrestaSharp.Entities.AuxEntities.language()
            {
                id = idLang,
                Value = libelle
            };
            languages.Add(language);
            return languages;
        }

        public static product_feature AddOrGetProductFeature(string libelle,ProductFeatureFactory productFeatureFactory)
        {
            Dictionary<string, string> dtnProductFeature = new Dictionary<string, string>();
            dtnProductFeature.Add("name", libelle);


            product_feature product_Feature = productFeatureFactory.GetByFilter(dtnProductFeature, null, null).FirstOrDefault();

            if (product_Feature is null)
            {
                var descriptionproduct_Feature = PSHelper.PSChampMultiLangue(libelle);
                product_Feature = new product_feature();
                product_Feature.name = descriptionproduct_Feature;
                product_Feature = productFeatureFactory.Add(product_Feature);

            }

            return product_Feature;
        }

        public static product_feature_value AddOrGetProductFeatureValue(string libelle, product_feature product_Feature,ProductFeatureValueFactory productFeatureValueFactory)
        {
            Dictionary<string, string> dtnProductFeatureValue = new Dictionary<string, string>();
            dtnProductFeatureValue.Add("id_feature", product_Feature.id.Value.ToString());
            dtnProductFeatureValue.Add("value", libelle);


            product_feature_value product_Feature_Value = productFeatureValueFactory.GetByFilter(dtnProductFeatureValue, null, null).FirstOrDefault();

            if (product_Feature_Value is null)
            {
                var descriptionproduct_FeatureValue = PSHelper.PSChampMultiLangue(libelle);

                product_Feature_Value = new product_feature_value();
                product_Feature_Value.id_feature = product_Feature.id.Value;
                product_Feature_Value.value = descriptionproduct_FeatureValue;

                product_Feature_Value = productFeatureValueFactory.Add(product_Feature_Value);


            }

            return product_Feature_Value;
        }

        public static product_option AddOrGetProductOption(string libelle,string libellePublic, ProductOptionFactory productOptionFactory)
        {
            Dictionary<string, string> dtnProductOption = new Dictionary<string, string>();
            dtnProductOption.Add("name", libelle);

            product_option product_Option = productOptionFactory.GetByFilter(dtnProductOption, null, null).FirstOrDefault();

            if (product_Option is null)
            {
                var descriptionproduct_Option = PSHelper.PSChampMultiLangue(libelle);
                var descriptionproduct_OptionPublic = PSHelper.PSChampMultiLangue(libellePublic);

                product_Option = new product_option();
                product_Option.name = descriptionproduct_Option;
                product_Option.public_name = descriptionproduct_OptionPublic;
                product_Option.group_type = "radio";
                product_Option = productOptionFactory.Add(product_Option);


            }

            return product_Option;
        }

        public static product_option_value AddOrGetProductOptionValue(string libelle, product_option product_Option, ProductOptionValueFactory productOptionValueFactory)
        {
            Dictionary<string, string> dtnProductOptionValue = new Dictionary<string, string>();
            dtnProductOptionValue.Add("name", libelle);
            dtnProductOptionValue.Add("id_attribute_group", product_Option.id.Value.ToString());

            product_option_value product_Option_Value = productOptionValueFactory.GetByFilter(dtnProductOptionValue, null, null).FirstOrDefault();

            if (product_Option_Value is null)
            {
                var descriptionproduct_Option_Value = PSHelper.PSChampMultiLangue(libelle);

                product_Option_Value = new product_option_value();
                product_Option_Value.id_attribute_group = product_Option.id;
                product_Option_Value.name = descriptionproduct_Option_Value;


                product_Option_Value = productOptionValueFactory.Add(product_Option_Value);


            }

            return product_Option_Value;
        }





        public static string GetTechnicalTab(TArticleEntete articleEntete,TSousFamille sousFamille)
        {
          
            string tableau = "";
            var attributs = sousFamille.AttributsPrestashop.Split("+");

            // Construction Entete

            tableau = $"<p><table width=\"100%\" class=\"spectab\">" +
              $"<tr class=\"spectabheader\">";

             

            foreach (var attribut in attributs)
            {
                var ChampTable = attribut.Replace("<", "").Replace(">", "");
                var ChampTableLibelle = ChampTable.Split(":");
                tableau = tableau + $"<td>\n<span><strong>{ChampTableLibelle[0]}</strong></span>\n</td>";
            }
            tableau = tableau + $"</tr>";
            var i = 0;
            //var tri = articleEntete.TArticleDetails.OrderBy(c => c.GetType().GetProperty(sousFamille.ChampTriAttributsPrestashop).GetValue(c)).DistinctBy(c => c.GetType().GetProperty(sousFamille.ChampTriAttributsPrestashop).GetValue(c));
            var tri = articleEntete.TArticleDetails
            .OrderBy(x => {
    if (double.TryParse(x.GetType().GetProperty(sousFamille.ChampTriAttributsPrestashop).GetValue(x)?.ToString(), out double result))
    {
        return result;
    }
    return double.MaxValue;
})
            .DistinctBy(c => c.GetType().GetProperty(sousFamille.ChampTriAttributsPrestashop).GetValue(c));
            
            
            foreach (var detail in tri)
            {
                tableau = tableau + $"<tr>";

                foreach (var attribut in attributs)
                {
                    var ChampTable = attribut.Replace("<", "").Replace(">", "").Split(".");
                    var ChampTableLibelle = ChampTable[0].Split(":");
                    var entityType = detail.GetType();
                    var property = entityType.GetProperty(ChampTableLibelle[1]);
                    var columnValue = "";
                    if (property.GetValue(detail) != null) {
                        columnValue = property.GetValue(detail).ToString();
                    }
                   tableau = tableau +$"<td>{(columnValue=="" ? "n.c":columnValue)}</td>";
                }

             
                tableau = tableau + $"</tr>";

            }

            tableau = tableau+ "</tbody></table></p>";
            return tableau;
        }
    }
}

