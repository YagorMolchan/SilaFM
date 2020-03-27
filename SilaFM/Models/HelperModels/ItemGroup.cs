using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pras.Web.Models.HelperModels
{
    public class ItemGroup
    {
        public ItemGroup()
        {
            Items = Items ?? new List<Item>();
        }

        [Display(Name = "Группа контактов")]
        public string Title { get; set; }
        [Display(Name = "Контакты")]
        public List<Item> Items { get; set; }
    }

    public class Item
    {
        [Display(Name = "Подпись")]
        public string Label { get; set; }
        [Display(Name = "Значение")]
        public string Value { get; set; }
        [Display(Name = "Ссылка")]
        public string Link { get; set; }
    }
}
