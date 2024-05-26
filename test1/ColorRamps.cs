using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;

namespace test1
{
    public partial class ColorRamps : Form
    {   
        /// <summary>
        /// 颜色梯度对象ColorRamps 四种可以创建的对象:
        /// Algorithmic ColorRamp（算法颜色梯度）
        /// MultiPart ColorRamp（多部分的颜色梯度）
        /// Random ColorRamp（随机颜色梯度）
        /// Preset ColorRamp（预定义颜色梯度）
        /// </summary>
        public ColorRamps()
        {
            InitializeComponent();
        }

        private IColorRamp CreateAlgorithmicColorRamp()
        {
            //创建一个新AlgorithmicColorRampClass对象
            IAlgorithmicColorRamp algColorRamp = new AlgorithmicColorRampClass();
            IRgbColor fromColor = new RgbColorClass();
            IRgbColor toColor = new RgbColorClass();
            //创建起始颜色对象
            fromColor.Red = 255;
            fromColor.Green = 10;
            fromColor.Blue = 0;
            //创建终止颜色对象           
            toColor.Red = 0;
            toColor.Green = 255;
            toColor.Blue = 0;
            //设置AlgorithmicColorRampClass的起止颜色属性
            algColorRamp.ToColor = fromColor;
            algColorRamp.FromColor = toColor;
            //设置梯度类型
            algColorRamp.Algorithm = esriColorRampAlgorithm.esriCIELabAlgorithm;
            //设置颜色带颜色数量
            algColorRamp.Size = 10;
            //创建颜色带
            bool bture = true;
            algColorRamp.CreateRamp(out bture);
            return algColorRamp;
        }

        private IColorRamp CreateMultiPartColorRamp()
        {
            IMultiPartColorRamp pMultiPartColorRamp = new MultiPartColorRampClass();
            bool bture = true;
            //叠加颜色带
            pMultiPartColorRamp.AddRamp(CreateAlgorithmicColorRamp());
            pMultiPartColorRamp.AddRamp(CreateRandomColorRamp());
            //设置颜色带颜色数量
            pMultiPartColorRamp.Size = 10;
            pMultiPartColorRamp.CreateRamp(out bture);
            return pMultiPartColorRamp;
        }

        private IColorRamp CreateRandomColorRamp()
        {
            IRandomColorRamp pRandomColorRamp = new RandomColorRampClass();
            // 制作一系列介于橘黄色和蓝绿色之间的随机颜色
            pRandomColorRamp.StartHue = 40;
            pRandomColorRamp.EndHue = 120;
            pRandomColorRamp.MinValue = 65;
            pRandomColorRamp.MaxValue = 90;
            pRandomColorRamp.MinSaturation = 25;
            pRandomColorRamp.MaxSaturation = 45;
            pRandomColorRamp.Size = 20;
            pRandomColorRamp.Seed = 23;
            bool bture = true;
            pRandomColorRamp.CreateRamp(out bture);
            return pRandomColorRamp;
        }
        private IColorRamp CreatePresetColorRamp()
        {
            IPresetColorRamp pPresetColorRamp = new PresetColorRampClass();
            IRgbColor rgbColor = new RgbColorClass();
            //预置颜色值
            for (int i = 0; i < 10; i++)
            {
                rgbColor.Red = 100 + 11 * i;
                rgbColor.Green = 100 + 5 * i;
                rgbColor.Blue = 0 + 8 * i;
                pPresetColorRamp.set_PresetColor(i, rgbColor as IColor);
            }
            pPresetColorRamp.Size = 10;
            bool bture = true;
            pPresetColorRamp.CreateRamp(out bture);
            return pPresetColorRamp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IEnumColors pEnumColors = null;
            //IColor color;            
            pEnumColors = CreateAlgorithmicColorRamp().Colors;
            pEnumColors.Reset();
            this.pictureBox1.BackColor = ColorTranslator.FromOle(pEnumColors.Next().RGB);
            this.pictureBox2.BackColor = ColorTranslator.FromOle(pEnumColors.Next().RGB);
            this.pictureBox3.BackColor = ColorTranslator.FromOle(pEnumColors.Next().RGB);
            this.pictureBox4.BackColor = ColorTranslator.FromOle(pEnumColors.Next().RGB);
            this.pictureBox5.BackColor = ColorTranslator.FromOle(pEnumColors.Next().RGB);
            this.pictureBox6.BackColor = ColorTranslator.FromOle(pEnumColors.Next().RGB);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            IEnumColors pEnumColors = null;
            IColor color;
            pEnumColors = CreateMultiPartColorRamp().Colors;
            pEnumColors.Reset();
            this.pictureBox1.BackColor = ColorTranslator.FromOle(pEnumColors.Next().RGB);
            this.pictureBox2.BackColor = ColorTranslator.FromOle(pEnumColors.Next().RGB);
            this.pictureBox3.BackColor = ColorTranslator.FromOle(pEnumColors.Next().RGB);
            this.pictureBox4.BackColor = ColorTranslator.FromOle(pEnumColors.Next().RGB);
            this.pictureBox5.BackColor = ColorTranslator.FromOle(pEnumColors.Next().RGB);
            this.pictureBox6.BackColor = ColorTranslator.FromOle(pEnumColors.Next().RGB);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IEnumColors pEnumColors = null;
            IColor color, fromColor, toColor;
            pEnumColors = CreateRandomColorRamp().Colors;
            pEnumColors.Reset();
            this.pictureBox1.BackColor = ColorTranslator.FromOle(pEnumColors.Next().RGB);
            this.pictureBox2.BackColor = ColorTranslator.FromOle(pEnumColors.Next().RGB);
            this.pictureBox3.BackColor = ColorTranslator.FromOle(pEnumColors.Next().RGB);
            this.pictureBox4.BackColor = ColorTranslator.FromOle(pEnumColors.Next().RGB);
            this.pictureBox5.BackColor = ColorTranslator.FromOle(pEnumColors.Next().RGB);
            this.pictureBox6.BackColor = ColorTranslator.FromOle(pEnumColors.Next().RGB);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IEnumColors pEnumColors = null;
            IColor color;
            pEnumColors = CreatePresetColorRamp().Colors;
            pEnumColors.Reset();
            this.pictureBox1.BackColor = ColorTranslator.FromOle(pEnumColors.Next().RGB);
            this.pictureBox2.BackColor = ColorTranslator.FromOle(pEnumColors.Next().RGB);
            this.pictureBox3.BackColor = ColorTranslator.FromOle(pEnumColors.Next().RGB);
            this.pictureBox4.BackColor = ColorTranslator.FromOle(pEnumColors.Next().RGB);
            this.pictureBox5.BackColor = ColorTranslator.FromOle(pEnumColors.Next().RGB);
            this.pictureBox6.BackColor = ColorTranslator.FromOle(pEnumColors.Next().RGB);
        }
    }
}
