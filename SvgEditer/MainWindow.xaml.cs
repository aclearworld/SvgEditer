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
        private List<FrameworkElement> editingFrameworkElements = new List<FrameworkElement>();

        /// <summary>
        /// 編集中のSvgエレメント
        /// </summary>
        private List<SvgVisualElement> editingSvgVisualElements = new List<SvgVisualElement>();

        /// <summary>
        /// 編集中のRectangle
        /// </summary>
        private  List<Rectangle> editingRectangles = new List<Rectangle>();

        /// <summary>
        /// 編集中のTextBoxs
        /// </summary>
        private  List<TextBox> editingTextBoxs = new List<TextBox>();

        /// <summary>
        /// 編集中のImages
        /// </summary>
        private  List<System.Windows.Controls.Image> editingImages = new List<System.Windows.Controls.Image>();

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
                        //var svgVisualElementType = findUiElementTypeBySvgVisualElementType.Key;
                        //var uiElementType = this.uiElementTypesBySvgVisualElementType[svgVisualElementType];
                        var svgVisualElement  = svgElement as SvgVisualElement;
                        this.editingSvgVisualElements.Add(svgVisualElement);

                        Rectangle rectangle = null;
                        Image image = null;
                        TextBox textBox = null;
                        switch (svgVisualElement.GetType().ToString())
                        {
                            case nameof(SvgRectangle):
                                SvgRectangle svgRectangle = svgVisualElement as SvgRectangle;

                                rectangle = new Rectangle();
                                this.editingFrameworkElements.Add(rectangle);
                                this.editingRectangles.Add(rectangle);
                                Canvas.SetLeft(rectangle, svgRectangle.X.Value);
                                Canvas.SetTop(rectangle, svgRectangle.Y.Value);


                                

                            case nameof(SvgImage):
                                image = new Image();
                                this.editingFrameworkElements.Add(image);
                                this.editingImages.Add(image);
                                return image;
                            case nameof(SvgText):
                                textBox = new TextBox();
                                this.editingFrameworkElements.Add(textBox);
                                this.editingTextBoxs.Add(textBox);
                                return textBox;
                            default:
                                break;
                        }


                    }

                }



            }


        }

        /// <summary>
        /// Svgエレメント=>Uiエレメント作成
        /// </summary>
        /// <param name="svgVisualElementType">編集対象のSvgエレメントタイプ</param>
        /// <param name="svgVisualElement">編集対象のSvgエレメント</param>
        private FrameworkElement GenerateUiElement(Type svgVisualElementType, SvgVisualElement svgVisualElement)
        {
          

            return null;
        }

        /// <summary>
        /// Canvasにエレメンを描画
        /// </summary>
        /// <param name="svgVisualElementType">編集対象のSvgエレメントタイプ</param>
        /// <param name="svgVisualElement">編集対象のSvgエレメント</param>
        //private void DrawUiElementToCanvas<T>(T frameworkElement, Type svgVisualElementType, SvgVisualElement svgVisualElement)
        //    where T : FrameworkElement
        //{
        //    new SvgRectangle().X.

        //    svgVisualElement.Path

        //}



    }
}
