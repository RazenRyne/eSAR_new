using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using eSAR.Utility_Classes;
using eSAR.App;
using eSARServices;
using eSARServiceInterface;
using eSARServiceModels;

namespace eSAR.Billing_and_Payment.StudentPayment
{
    public partial class frmPaymentDetails : Telerik.WinControls.UI.RadForm
    {
        IRegistrationService registrationService = new RegistrationService();
        IPaymentService paymentService = new PaymentService();
        IStudentService studentService = new StudentService();

        Student Student = new Student();
       Student Studentv2 = new Student();

        Payment Payment = new Payment();
        PaymentDetail paymentDetails = new PaymentDetail();
        List<PaymentDetail> paymentDetailsList = new List<PaymentDetail>(new PaymentDetail[1]);

        List<Student> studentsv2 = new List<Student>();

        List<Student> students = new List<Student>();
        List<Student> tempStudents;
        List<Student> studentResult = new List<Student>();

        


        public frmPaymentDetails()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {

            string message = string.Empty;

            string StudentID = txtStudentID.Text.ToString();

            Student = registrationService.GetStudent(txtStudentID.Text, ref message);

            Studentv2 = studentService.GetStudent(txtStudentID.Text, ref message);

            if (StudentID == "")
            {
                MessageBox.Show("Please provide the ID Number");
                txtStudentID.Text = string.Empty;
                txtStudentID.Focus();
                return;
            }
            else if (Studentv2.StudentId == null)
            {
                MessageBox.Show("ID Number does not exist", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtStudentID.Text = string.Empty;
                txtStudentID.Focus();
                return;
            }
            else {
                
                SetFields();
                studentsv2.Add(Studentv2);
                if (studentsv2.Count == 2)
                {
                    studentsv2.RemoveAt(0);
                    this.gvStudentList.DataSource = null;
                    this.gvStudentList.Rows.Clear();
                    this.gvStudentList.DataSource = studentsv2;
                }
                else {
                    this.gvStudentList.DataSource = studentsv2;
                }
            }
        }

        private void SetFields()
        {
            txtStudentID.Enabled = true;
            gvStudentList.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            GlobalClass.WindowStatusPaymentDetails = false;
            Close();
        }

        private void txtUnits_TextChanged(object sender, EventArgs e)
        {
            //if (txtPayment.Text.Equals(String.Empty)) txtPayment.Text = "0";
        }

        private void txtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            RadTextBox textBox = (RadTextBox)sender;
            // only allow one decimal point
            if (e.KeyChar == '.' && textBox.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            if (!char.IsControl(e.KeyChar) && textBox.SelectionLength == 0)
            {
                if (textBox.Text.IndexOf('.') > -1 && textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= 3)
                {
                    e.Handled = true;
                }
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (gvStudentList.CurrentRow == null)
                return;

            if (txtPayment.Text == String.Empty)
                return;
            else
            {
                if (double.Parse(txtPayment.Text) == 0)
                    return;
            }


            if (Student.RunningBalance == 0)
                return;
            

            if (GlobalClass.receiptFrom == null)
            {
                MessageBox.Show("Set Receipt Number First");
            }
            else
            {
                PaymentReceiptDetails prd = new PaymentReceiptDetails();

                if (Int32.Parse(GlobalClass.receiptCurrent) <= Int32.Parse(GlobalClass.receiptTo))
                {
                    int tempReceipt;

                    tempReceipt = Int32.Parse(GlobalClass.receiptCurrent);
                    MessageBox.Show("Receipt Number From:                           " + GlobalClass.receiptFrom + "\n" + "Receipt Number To:                                " + GlobalClass.receiptTo + "\n" + "Receipt Number For This Transaction: " + GlobalClass.receiptCurrent);


                    Boolean ret = false;
                    string message = String.Empty;
                    string StudentId = txtStudentID.Text.ToString();
                    Student = registrationService.GetStudent(StudentId, ref message);
                    float runningBalanceProv = float.Parse(txtPayment.Text);
                    float runningBalanceNew;
                    float runningBalanceOld = Student.RunningBalance;
                    runningBalanceNew = runningBalanceOld - runningBalanceProv;

                    if (runningBalanceNew < 0)
                    {
                        
                        string balance = runningBalanceNew.ToString();
                        MessageBox.Show("Amount paid: " + runningBalanceProv + "\n" + "Change is: " + Math.Abs(runningBalanceNew));

                        prd.ORno = tempReceipt;
                        prd.StudentID = txtStudentID.Text;
                        prd.StudentName = Student.LastName + ", " + Student.FirstName + " " + Student.MiddleName.Substring(0, 1) + ".";
                        prd.Amount = runningBalanceOld;
                        prd.ShowDialog();

                        if (prd.btnPushed == "Generate Receipt")
                        {
                            //Payment Table
                            Payment.ORNo = tempReceipt;
                            Payment.StudentId = txtStudentID.Text;
                            Payment.ReceivedFrom = prd.ReceivedFrom;
                            Payment.TIN = prd.TIN;
                            Payment.BusinessStyle = prd.BusinessStyle;
                            Payment.SettlementFor = prd.PartialFull;
                            Payment.PaidTo = GlobalClass.user.UserId;
                            Payment.Cancelled = false;
                            Payment.Amount = prd.Amount;
                            Payment.PaidAt = DateTime.Now.ToString();


                            txtPayment.Clear();
                            gvStudentList.DataSource = null;

                            //Payment Transaction
                            paymentService.CreatePayment(ref Payment, ref message);

                            //Receipt
                            tempReceipt = tempReceipt + 1;
                            GlobalClass.receiptCurrent = tempReceipt.ToString();

                            Student.RunningBalance = 0;
                            ret = registrationService.UpdateStudent(ref Student, ref message);
                            students.Add(Student);

                            if (students.Count == 2)
                            {
                                students.RemoveAt(0);
                                this.gvStudentList.DataSource = null;
                                this.gvStudentList.Rows.Clear();
                                this.gvStudentList.DataSource = students;
                            }
                            else
                            {
                                this.gvStudentList.DataSource = students;
                            }

                            gvStudentList.Update();
                            gvStudentList.Refresh();

                        }
                        
                        
                    }
                    else if (runningBalanceNew == 0)
                    {
                         string balance = runningBalanceNew.ToString();
                        MessageBox.Show("Amount paid: " + runningBalanceProv + "\n" + "Change is: " + Math.Abs(runningBalanceNew));


                        prd.ORno = tempReceipt;
                        prd.StudentID = txtStudentID.Text;
                        prd.StudentName = Student.LastName + ", " + Student.FirstName + " " + Student.MiddleName.Substring(0, 1) + ".";
                        prd.Amount = float.Parse(txtPayment.Text);
                        prd.ShowDialog();

                        if (prd.btnPushed == "Generate Receipt")
                        {
                            //Payment Table
                            Payment.ORNo = tempReceipt;
                            Payment.StudentId = txtStudentID.Text;
                            Payment.ReceivedFrom = prd.ReceivedFrom;
                            Payment.TIN = prd.TIN;
                            Payment.BusinessStyle = prd.BusinessStyle;
                            Payment.SettlementFor = prd.PartialFull;
                            Payment.PaidTo = GlobalClass.user.UserId;
                            Payment.Cancelled = false;
                            Payment.Amount = prd.Amount;
                            Payment.PaidAt = DateTime.Now.ToString();

                           

                            txtPayment.Clear();
                            gvStudentList.DataSource = null;


                            //Payment Transaction
                            paymentService.CreatePayment(ref Payment, ref message);


                            //Receipt
                            tempReceipt = tempReceipt + 1;
                            GlobalClass.receiptCurrent = tempReceipt.ToString();

                            Student.RunningBalance = 0;
                            ret = registrationService.UpdateStudent(ref Student, ref message);
                            students.Add(Student);
                            if (students.Count == 2)
                            {
                                students.RemoveAt(0);
                                this.gvStudentList.DataSource = null;
                                this.gvStudentList.Rows.Clear();
                                this.gvStudentList.DataSource = students;
                            }
                            else
                            {
                                this.gvStudentList.DataSource = students;
                            }

                            gvStudentList.Update();
                            gvStudentList.Refresh();
                        }
                    }
                    else
                    {
                       string balance = runningBalanceNew.ToString();
                        MessageBox.Show("Amount paid: " + runningBalanceProv + "\n" + "Current Balance is: " + Math.Abs(runningBalanceNew));


                        prd.ORno = tempReceipt;
                        prd.StudentID = txtStudentID.Text;
                        prd.StudentName = Student.LastName + ", " + Student.FirstName + " " + Student.MiddleName.Substring(0, 1) + ".";
                        prd.Amount = float.Parse(txtPayment.Text);
                        prd.ShowDialog();

                        if (prd.btnPushed == "Generate Receipt")
                        {
                            //Payment Table
                            Payment.ORNo = tempReceipt;
                            Payment.StudentId = txtStudentID.Text;
                            Payment.ReceivedFrom = prd.ReceivedFrom;
                            Payment.TIN = prd.TIN;
                            Payment.BusinessStyle = prd.BusinessStyle;
                            Payment.SettlementFor = prd.PartialFull;
                            Payment.PaidTo = GlobalClass.user.UserId;
                            Payment.Cancelled = false;
                            Payment.Amount = prd.Amount;
                            Payment.PaidAt = DateTime.Now.ToString();

                            

                            txtPayment.Clear();
                            gvStudentList.DataSource = null;

                            //Payment Transaction
                            paymentService.CreatePayment(ref Payment, ref message);

                            //Receipt
                            tempReceipt = tempReceipt + 1;
                            GlobalClass.receiptCurrent = tempReceipt.ToString();

                            Student.RunningBalance = runningBalanceNew;
                            ret = registrationService.UpdateStudent(ref Student, ref message);
                            students.Add(Student);
                            if (students.Count == 2)
                            {
                                students.RemoveAt(0);
                                this.gvStudentList.DataSource = null;
                                this.gvStudentList.Rows.Clear();
                                this.gvStudentList.DataSource = students;
                            }
                            else
                            {
                                this.gvStudentList.DataSource = students;
                            }

                            gvStudentList.Update();
                            gvStudentList.Refresh();
                        }

                    }

                    if (prd.btnPushed == "Cancel")
                    {
                        if (ret)
                            MessageBox.Show("Saved Successfully");
                        else
                            MessageBox.Show("Error Saving");
                    }
                    GlobalClass.WindowStatusPaymentDetails = false;
                }
                else
                {
                    MessageBox.Show("No More Receipt");
                }
            }
        }

     
    }
}
