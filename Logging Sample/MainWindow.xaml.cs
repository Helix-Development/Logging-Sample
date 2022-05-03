using Logging_Sample.Logs;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Drawing;

namespace Logging_Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
			TextSample.Document.Blocks.Remove(TextSample.Document.Blocks.FirstBlock);
			LogEvents.OnWrite += OnWrite;
        }

		private void OnWrite(string message, Color col)
		{
			try
			{
				AppendMessage(TextSample, message, col);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}

		}

		private static void AppendMessage(RichTextBox textBox, string message, Color col)
		{
			try
			{
				if (!textBox.Dispatcher.CheckAccess())
				{
					textBox.Dispatcher.Invoke(new Action<RichTextBox, string, Color>(AppendMessage), new object[]
					{
							textBox,
							message,
							col
					});
				}
				else
				{
					Paragraph paragraph = new Paragraph(new Run(message));
					paragraph.Foreground = new System.Windows.Media.SolidColorBrush(new System.Windows.Media.Color
					{
						A = col.A,
						R = col.R,
						G = col.G,
						B = col.B
					});
					paragraph.FontSize = 13;
					textBox.Document.Blocks.Add(paragraph);
					textBox.ScrollToEnd();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
			Logging.WriteDebug("Test");
			Logging.Write("Test");
		}
    }
}
