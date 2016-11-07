
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
    public partial class PieChart : Telerik.WinControls.UI.RadForm
    {
        List<StudentEnrollment> stEnrolled;
        string groupedBy;
        string sY;
        IRegistrationService regService = new RegistrationService();

        public PieChart()
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

            PieSeries series = new PieSeries();
            series.ShowLabels = true;

            iCntMale = stEnrolled.FindAll(x => x.student.Gender == "M").Count;
            if (iCntMale > 0)
                series.DataPoints.Add(new PieDataPoint(iCntMale, "Male"));

            iCntFemale = stEnrolled.FindAll(x => x.student.Gender == "F").Count;
            if (iCntFemale > 0)
                series.DataPoints.Add(new PieDataPoint(iCntFemale, "Female"));

       
            this.radChartView1.Series.Add(series);


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

            PieSeries series = new PieSeries();
            series.ShowLabels = true;

            foreach (String religion in aReligion)
            {
                iCntReligionMale = stEnrolled.FindAll(x => x.student.Religion == religion && x.student.Gender == "M").Count;
                if (iCntReligionMale  > 0)
                    series.DataPoints.Add(new PieDataPoint(iCntReligionMale, religion + " Boys"));

                iCntReligionFemale = stEnrolled.FindAll(x => x.student.Religion == religion && x.student.Gender == "F").Count;
                if (iCntReligionFemale > 0)
                    series.DataPoints.Add(new PieDataPoint(iCntReligionFemale, religion + " Girls"));
            }

            this.radChartView1.Series.Add(series);

        }

        private void loadGradeLevelList()
        {
            List<GradeLevel> sortedGL = new List<GradeLevel>();
            List<GradeLevel> gradeLevel = new List<GradeLevel>(regService.GetAllGradeLevel());
            gradeLevel.RemoveAll(x => x.GradeLev == "0");

            int iCntGradeLevelMale = 0;
            int iCntGradeLevelFemale = 0;

            PieSeries series = new PieSeries();
            series.ShowLabels = true;

            foreach (GradeLevel gl in gradeLevel)
            {
                iCntGradeLevelMale = stEnrolled.FindAll(x => x.student.GradeLevel == gl.GradeLev && x.student.Gender == "M").Count;
                if (iCntGradeLevelMale > 0)
                    series.DataPoints.Add(new PieDataPoint(iCntGradeLevelMale, gl.Description + " Boys"));
       

                iCntGradeLevelFemale = stEnrolled.FindAll(x => x.student.GradeLevel == gl.GradeLev && x.student.Gender == "F").Count;
                if (iCntGradeLevelFemale > 0)
                    series.DataPoints.Add(new PieDataPoint(iCntGradeLevelFemale, gl.Description + " Girls"));
            }

            this.radChartView1.Series.Add(series);


        }

        private void loadGradeSectionList()
        {
            this.radChartView1.Series.Clear();
            List<GradeSection> gs = new List<GradeSection>(regService.GetAllGradeSection(cmbGradeLevel.SelectedValue.ToString()));

            int iCntGradeSectionMale = 0;
            int iCntGradeSectionFemale = 0;
            string gradelevel = cmbGradeLevel.SelectedValue.ToString();

            PieSeries series = new PieSeries();
            series.ShowLabels = true;

            foreach (GradeSection section in gs)
            {
                iCntGradeSectionMale = stEnrolled.FindAll(x => x.GradeLevel == gradelevel && x.GradeSectionCode == section.GradeSectionCode && x.student.Gender == "M").Count;
                if (iCntGradeSectionMale > 0)
                    series.DataPoints.Add(new PieDataPoint(iCntGradeSectionMale, section.Section + " Boys"));

                iCntGradeSectionFemale = stEnrolled.FindAll(x => x.GradeLevel == gradelevel && x.GradeSectionCode == section.GradeSectionCode && x.student.Gender == "F").Count;
                if (iCntGradeSectionFemale > 0)
                    series.DataPoints.Add(new PieDataPoint(iCntGradeSectionFemale, section.Section + " Girls"));
            }
          
            this.radChartView1.Series.Add(series);


        }

        private void PieChart_Load(object sender, EventArgs e)
        {
            this.radChartView1.AreaType = ChartAreaType.Pie;
            radChartView1.Controllers.Add(new ChartSelectionController());
            radChartView1.SelectionMode = ChartSelectionMode.SingleDataPoint;
            radChartView1.SelectedPointChanged += new ChartViewSelectedChangedEventHandler(radChartView1_SelectedPointChanged);

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

        void radChartView1_SelectedPointChanged(object sender, ChartViewSelectedPointChangedEventArgs args)
        {
            if (args.NewSelectedPoint != null)
            {
                UpdateSelectedPoint(args.NewSelectedPoint);
            }
            if (args.OldSelectedPoint != null)
            {
                UpdateSelectedPoint(args.OldSelectedPoint);
            }
        }

        void UpdateSelectedPoint(DataPoint point)
        {
            PieDataPoint pieDataPoint = point as PieDataPoint;
            if (pieDataPoint != null)
            {
                if (pieDataPoint.IsSelected)
                {
                    pieDataPoint.OffsetFromCenter = 0.1;
                }
                else
                {
                    pieDataPoint.OffsetFromCenter = 0;
                }
            }
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

        private void cmbGradeLevel_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
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
