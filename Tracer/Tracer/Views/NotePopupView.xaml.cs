using System;
using Xamarin.Forms;

namespace Tracer.Views
{
    public partial class NotePopupView : ContentView
    {
        public delegate void TapDelegate();
        public NotePopupView()
        {
            InitializeComponent();
            GoToState("Collapsed");
        }
        public int PageHeader { get; private set; } = 70;
        
        public TapDelegate OnExpandTapped { get; set; }
        public TapDelegate OnCollapseTapped { get; set; }
        public void ExpandTapped(object sender, System.EventArgs e)
        {
            GoToState("Expanded");
            OnExpandTapped?.Invoke();
        }
        private void CollapseTapped(object sender, System.EventArgs e)
        {
            GoToState("Collapsed");
            OnCollapseTapped?.Invoke();
        }
        private void GoToState(string visualState)
        {
            VisualStateManager.GoToState(ExpandButton, visualState);
            VisualStateManager.GoToState(CollapseButton, visualState);
        }

        private void AddNotes(object sender, EventArgs e)
        {
            
        }
    }
}