using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace LogMonitoringApp.Pages.Logs.Controls
{
    public partial class LogListControl : UserControl
    {
        public ObservableCollection<LogEntry> LogEntries { get; set; }

        public LogListControl()
        {
            InitializeComponent();

            // 샘플 데이터 생성
            LogEntries = new ObservableCollection<LogEntry>
            {
                new LogEntry { IsSelected = false, Timestamp = "2023-01-01 12:00", Severity = "정보", LogCategory = "시스템", LogId = "ID001", Message = "로그 메시지 1", User = "사용자1" },
                new LogEntry { IsSelected = false, Timestamp = "2023-01-01 12:05", Severity = "경고", LogCategory = "애플리케이션", LogId = "ID002", Message = "로그 메시지 2", User = "사용자2" }
            };

            LogDataGrid.ItemsSource = LogEntries;
        }

        private void SelectAllCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox headerCheckBox)
            {
                bool isChecked = headerCheckBox.IsChecked == true;
                foreach (var entry in LogEntries)
                {
                    entry.IsSelected = isChecked;
                }
            }
        }
    }

    public class LogEntry : INotifyPropertyChanged
    {
        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }

        public string Timestamp { get; set; } = string.Empty;
        public string Severity { get; set; } = string.Empty;
        public string LogCategory { get; set; } = string.Empty;
        public string LogId { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string User { get; set; } = string.Empty;

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
