using eSARServices;
using eSARServiceInterface;
using eSARServiceModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.Charting;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace eSAR.Reports
{
    public partial class BarChart : Telerik.WinControls.UI.RadForm
    {
        List<StudentEnrollment> stEnrolled;
        string groupedBy;
        string sY;
        IRegistrationService regService = new RegistrationService();

        public BarChart()
        {
            InitializeComponent();
        }

        public void setVars(string szGroupedBy, string szSY)
        {
            groupedBy = szGroupedBy;
            sY = szSY;
        }

        private void loadGenderList()
        {
            int iCntMale = 0;
            int iCntFemale = 0;
           
            BarSeries series = new BarSeries();


            iCntMale = stEnrolled.FindAll(x => x.student.Gender == "M").Count;
                series.DataPoints.Add(new CategoricalDataPoint(iCntMale, "Male"));

            iCntFemale = stEnrolled.FindAll(x => x.student.Gender == "F").Count;
                series.DataPoints.Add(new CategoricalDataPoint(iCntFemale, "Female"));            

            this.radChartView1.Series.Add(series);

            CategoricalAxis categoricalAxis = radChartView1.Axes[0] as CategoricalAxis;
            categoricalAxis.PlotMode = AxisPlotMode.OnTicksPadded;
            categoricalAxis.LabelFitMode = AxisLabelFitMode.Rotate;
            categoricalAxis.LabelRotationAngle = 310;


        }

        private void loadReligionList()
        {
            List<string> aReligion = new List<string>();           
            int iCntReligionMale = 0;
            int iCntReligionFemale = 0;

            foreach (StudentEnrollment se in stEnrolled)
            {
                if (!aReligion.Contains(se.student.Religion))
                {
                    aReligion.Add(se.student.Religion);
                }
            }

            BarSeries series = new BarSeries();
            BarSeries series2 = new BarSeries();

            foreach (String religion in aReligion)
            {
                iCntReligionMale = stEnrolled.FindAll(x => x.student.Religion == religion && x.student.Gender == "M").Count;
                series.DataPoints.Add(new CategoricalDataPoint(iCntReligionMale, religion));

                iCntReligionFemale = stEnrolled.FindAll(x => x.student.Religion == religion && x.student.Gender == "F").Count;
                series2.DataPoints.Add(new CategoricalDataPoint(iCntReligionFemale, religion));
            }

            this.radChartView1.Series.Add(series);
            this.radChartView1.Series.Add(series2);

            CategoricalAxis categoricalAxis = radChartView1.Axes[0] as CategoricalAxis;
            categoricalAxis.PlotMode = AxisPlotMode.OnTicksPadded;
            categoricalAxis.LabelFitMode = AxisLabelFitMode.Rotate;
            categoricalAxis.LabelRotationAngle = 310;

            this.radChartView1.ShowLegend = true;
            this.radChartView1.LegendTitle = "Legend";
            this.radChartView1.ChartElement.LegendPosition = LegendPosition.Right;

            this.radChartView1.ChartElement.LegendElement.Items[0].Title = "Male";
            this.radChartView1.ChartElement.LegendElement.Items[1].Title = "Female";


        }

        private void loadGradeLevelList()
        {
            List<GradeLevel> sortedGL = new List<GradeLevel>();
            List<GradeLevel> gradeLevel = new List<GradeLevel>(regService.GetAllGradeLevel());
            gradeLevel.RemoveAll(x => x.GradeLev == "0");

            int iCntGradeLevelMale = 0;
            int iCntGradeLevelFemale = 0;

            BarSeries series = new BarSeries();
            BarSeries series2 = new BarSeries();

            foreach (GradeLevel gl in gradeLevel)
            {
                iCntGradeLevelMale = stEnrolled.FindAll(x => x.student.GradeLevel == gl.GradeLev && x.student.Gender == "M").Count;
                series.DataPoints.Add(new CategoricalDataPoint(iCntGradeLevelMale, gl.Description));

                iCntGradeLevelFemale = stEnrolled.FindAll(x => x.student.GradeLevel == gl.GradeLev && x.student.Gender == "F").Count;
                series2.DataPoints.Add(new CategoricalDataPoint(iCntGradeLevelFemale, gl.Description));
            }

            

            this.radChartView1.Series.Add(series);
            this.radChartView1.Series.Add(series2);

            CategoricalAxis categoricalAxis = radChartView1.Axes[0] as CategoricalAxis;
            categoricalAxis.PlotMode = AxisPlotMode.OnTicksPadded;
            categoricalAxis.LabelFitMode = AxisLabelFitMode.Rotate;
            categoricalAxis.LabelRotationAngle = 310;

            this.radChartView1.ShowLegend = true;
            this.radChartView1.LegendTitle = "Legend";
            this.radChartView1.ChartElement.LegendPosition = LegendPosition.Right;

            this.radChartView1.ChartElement.LegendElement.Items[0].Title = "Male";
            this.radChartView1.ChartElement.LegendElement.Items[1].Title = "Female";


        }

        private void loadGradeSectionList()
        {
            this.radChartView1.Series.Clear();
            List<GradeSection> gs = new List<GradeSection>(regService.GetAllGradeSection(cmbGradeLevel.SelectedValue.ToString()));

            int iCntGradeSectionMale = 0;
            int iCntGradeSectionFemale = 0;
            string gradelevel = cmbGradeLevel.SelectedValue.ToString();

            BarSeries series = new BarSeries();
            
            BarSeries series2 = new BarSeries();

            foreach (GradeSection section in gs)
            {
                iCntGradeSectionMale = stEnrolled.FindAll(x => x.GradeLevel == gradelevel && x.GradeSectionCode == section.GradeSectionCode && x.student.Gender == "M").Count;
                series.DataPoints.Add(new CategoricalDataPoint(iCntGradeSectionMale, section.Section));

                iCntGradeSectionFemale = stEnrolled.FindAll(x => x.GradeLevel == gradelevel && x.GradeSectionCode == section.GradeSectionCode && x.student.Gender == "F").Count;
                series2.DataPoints.Add(new CategoricalDataPoint(iCntGradeSectionFemale, section.Section));
            }

            this.radChartView1.Series.Add(series);
            this.radChartView1.Series.Add(series2);

            CategoricalAxis categoricalAxis = radChartView1.Axes[0] as CategoricalAxis;
            categoricalAxis.PlotMode = AxisPlotMode.OnTicksPadded;
            categoricalAxis.LabelFitMode = AxisLabelFitMode.Rotate;
            categoricalAxis.LabelRotationAngle = 310;

            this.radChartView1.ShowLegend = true;
            this.radChartView1.LegendTitle = "Legend";
            this.radChartView1.ChartElement.LegendPosition = LegendPosition.Right;

            this.radChartView1.ChartElement.LegendElement.Items[0].Title = "Male";
            this.radChartView1.ChartElement.LegendElement.Items[1].Title = "Female";


        }

        private void BarChart_Load(object sender, EventArgs e)
        {
            stEnrolled = new List<StudentEnrollment>(regService.GetCurrentStudents(sY));

            switch (groupedBy)
            {
                case "Religion":
                    loadReligionList();
                    break;
                case "Gender":
                    loadGenderList();
                    break;
                case "Grade Level":
                    loadGradeLevelList();
                    break;
                case "Section":
                    loadCombo();
                    loadGradeSectionList();
                    lblGradeLevel.Visible = true;
                    cmbGradeLevel.Visible = true;
                    break;
            }

            this.radChartView1.Area.View.Palette = KnownPalette.Lilac;
            radChartView1.ShowToolTip = true;

           
        }

        private void loadCombo()
        {
            
            List<GradeLevel> gradeLevel = new List<GradeLevel>(regService.GetAllGradeLevel());
            gradeLevel.RemoveAll(x => x.GradeLev == "0");
            cmbGradeLevel.DataSource = gradeLevel;

            if (gradeLevel.Count > 0)
                cmbGradeLevel.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbGradeLevel_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbGradeLevel.SelectedIndex >= 0)
                loadGradeSectionList();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            RadPrintDocument document = new RadPrintDocument();
            document.DefaultPageSettings.Landscape = true;
            document.HeaderHeight = 60;
            document.HeaderFont = new Font("Arial", 10, FontStyle.Bold);
            document.MiddleHeader = "Dansalan College Foundation, Inc. \r\n Marinaut, Marawi City, Lanao del Sur";
            document.MiddleFooter = "Page [Page #] of [Total Pages]";
            document.AssociatedObject = this.radChartView1;
            radPrintDocument1 = document;

            RadPrintPreviewDialog dialog = new RadPrintPreviewDialog();
            dialog.Document = this.radPrintDocument1;
            dialog.ShowDialog();
        }
    }
}
