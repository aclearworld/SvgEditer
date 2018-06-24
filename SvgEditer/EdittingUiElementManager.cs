using Svg;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SvgEditer
{
    /// <summary>
    /// 編集中のUiElementを管理します
    /// シングルトンパターン
    /// </summary>
    public sealed class EdittingUiElementManager
    {
        /// <summary>
        /// シングルトンインスタンス
        /// </summary>
        private static EdittingUiElementManager instance = new EdittingUiElementManager();

        /// <summary>
        /// 編集中のレイヤー
        /// </summary>
        private static List<UIElement> editingUiElements = new List<UIElement>();

        /// <summary>
        /// 編集中のRectangle
        /// </summary>
        private static List<Rectangle> editingRectangles = new List<Rectangle>();

        /// <summary>
        /// 編集中のTextBoxs
        /// </summary>
        private static List<TextBox> editingTextBoxs = new List<TextBox>();

        /// <summary>
        /// 編集中のImages
        /// </summary>
        private static List<System.Windows.Controls.Image> editingImages = new List<System.Windows.Controls.Image>();

        /// <summary>
        /// 編集中のSvgエレメント
        /// </summary>
        private static List<SvgVisualElement> editingSvgVisualElements = new List<SvgVisualElement>();

        /// <summary>
        /// 編集対象Svgエレメント:編集Uiエレメント対応定義
        /// key : 編集対象Svgエレメント
        /// value : 編集Uiエレメント
        /// </summary>
        private static Dictionary<Type, Type> uiElementTypesBySvgVisualElementType = new Dictionary<Type, Type>()
        {
            {typeof(SvgRectangle),typeof(Rectangle) },
            {typeof(SvgImage) ,typeof(System.Windows.Controls.Image) },
            {typeof(SvgText),typeof(TextBox) },
        };

        /// <summary>
        /// コンストラクタ
        /// </summary>
        private EdittingUiElementManager()
        {
        }

        /// <summary>
        /// 編集中のレイヤー
        /// </summary>
        public static List<UIElement> EditingUiElements
        {
            get => editingUiElements;
            set => editingUiElements = value;
        }

        /// <summary>
        /// 編集中のSvgエレメント
        /// </summary>
        public static List<SvgVisualElement> EditingSvgVisualElements
        {
            get => editingSvgVisualElements;
            set => editingSvgVisualElements = value;
        }

        /// <summary>
        /// 編集対象Svgエレメント:編集Uiエレメント対応定義
        /// key : 編集対象Svgエレメント
        /// value : 編集Uiエレメント
        /// </summary>
        public static Dictionary<Type, Type> UiElementTypesBySvgVisualElementType
        {
            get => uiElementTypesBySvgVisualElementType;
            set => uiElementTypesBySvgVisualElementType = value;
        }

        public static List<Rectangle> EditingRectangles { get => editingRectangles; set => editingRectangles = value; }
        public static List<TextBox> EditingTextBoxs { get => editingTextBoxs; set => editingTextBoxs = value; }
        public static List<System.Windows.Controls.Image> EditingImages { get => editingImages; set => editingImages = value; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static EdittingUiElementManager Initialization()
        {
            return instance;
        }






    }
}
