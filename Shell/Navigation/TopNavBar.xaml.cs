using System;
using System.Windows;
using System.Windows.Controls;

namespace LogMonitoringApp.Shell.Navigation
{
    public partial class TopNavBar : UserControl
    {
        // 이벤트를 nullable로 선언
        public event EventHandler<int>? TabButtonClicked;

        public TopNavBar()
        {
            InitializeComponent();
        }

        private void OnRadioTabChecked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton rb && int.TryParse(rb.Tag?.ToString(), out int index))
            {
                TabButtonClicked?.Invoke(this, index);
            }
        }
    }
}
