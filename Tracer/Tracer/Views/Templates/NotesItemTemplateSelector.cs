using System;
using Tracer.Models;
using Xamarin.Forms;

namespace Tracer.Views.Templates
{
    class NotesItemTemplateSelector: DataTemplateSelector
    {
        public DataTemplate ActivityTemplate { get; set; }
        public DataTemplate TodoTemplate { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((NotesItem)item).Type == NotesItemType.Activity ? ActivityTemplate : TodoTemplate;
        }
    }
}
