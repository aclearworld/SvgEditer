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
        /// 編集中のレイヤー
        /// </summary>
        private List<UIElement> editingUiElements = new List<UIElement>();

        /// <summary>
        /// 編集中のSvgエレメント
        /// </summary>
        private List<SvgVisualElement> editingSvgVisualElements = new List<SvgVisualElement>();

        /// <summary>
        /// 編集対象Svgエレメント:編集Uiエレメント対応定義
        /// key : 編集対象Svgエレメント
        /// value : 編集Uiエレメント
        /// </summary>
        private Dictionary<Type, Type> uiElementTypesBySvgVisualElementType = new Dictionary<Type, Type>()
        {
            {typeof(SvgRectangle),typeof(Rectangle) },
            {typeof(SvgImage) ,typeof(Image) },
            {typeof(SvgText),typeof(TextBox) },
        };

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



            var svgElements = this.svgDoc.Children;
            foreach (var svgElement in svgElements)
            {
                if (svgElement != null && svgElement is SvgVisualElement)
                {
                    var findUiElementTypeBySvgVisualElementType = this.uiElementTypesBySvgVisualElementType.FirstOrDefault(
                        uiElementTypeBySvgVisualElementType => uiElementTypeBySvgVisualElementType.Key == svgElement.GetType());
                    if (!findUiElementTypeBySvgVisualElementType.Equals(default(KeyValuePair<Type, Type>)))
                    {
                        this.SetTargetSvgVisualElements(findUiElementTypeBySvgVisualElementType.Key, svgElement as SvgVisualElement);



                    }

                }



            }


        }

        /// <summary>
        /// 編集対象のSvgエレメントを格納
        /// </summary>
        /// <param name="elementType">編集対象のSvgエレメントタイプ</param>
        /// <param name="svgVisualElement">編集対象のSvgエレメント</param>
        private void SetTargetSvgVisualElements(Type elementType, SvgVisualElement svgVisualElement)
        {
            if (elementType != null &&
                svgVisualElement != null)
            {
                this.editingSvgVisualElements.Add(svgVisualElement);
                this.GenerateUiElement(elementType, svgVisualElement);

            }
        }


        /// <summary>
        /// Svgエレメント=>Uiエレメント作成
        /// </summary>
        /// <param name="elementType">編集対象のSvgエレメントタイプ</param>
        /// <param name="svgVisualElement">編集対象のSvgエレメント</param>
        private void GenerateUiElement(Type elementType, SvgVisualElement svgVisualElement)
        {
            var uiElementType = this.uiElementTypesBySvgVisualElementType[elementType];

                Activator.CreateInstance(uiElementType);



            this.editingUiElements.Add();
        }



    }
}
