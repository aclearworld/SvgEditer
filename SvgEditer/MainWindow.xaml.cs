using Svg;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SvgEditer
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 編集対象Svgファイル
        /// </summary>
        private SvgDocument svgDoc;


        /// <summary>
        /// Constructer
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            MessageBox.Show(Directory.GetCurrentDirectory().ToString());
            this.svgDoc = Svg.SvgDocument.Open(@".\taarget.svg");

            var bitmap = this.svgDoc.Draw();
            this.image.Source = Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());




        }
    }
}
