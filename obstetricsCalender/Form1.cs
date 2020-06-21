using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
namespace obstetricsCalender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
         }
        private void Form1_Load(object sender, EventArgs e)
        {
            PersianCalendar pc = new PersianCalendar();

            label3.Text = pc.GetYear(DateTime.Now) + "/" + pc.GetMonth(DateTime.Now) + "/" + pc.GetDayOfMonth(DateTime.Now) + "   تاریخ امروز   ";

            datePikerLmp.Value = DateTime.Now;
            datepikerlab.Value = DateTime.Now;
            selectWeak.SelectedIndex = 0;
            selectDay.SelectedIndex = 0;
        }
        private void btnlmp_Click(object sender, EventArgs e)
        {
           
            DateTime? dt1=datePikerLmp.Value;
            DateTime dt;
           // if(dt1.HasValue){
                dt = dt1.Value;
                if (dt.Date.CompareTo(DateTime.Now) > 0)
                    MessageBox.Show(" تاریخ اولین روز از آخرین قاعدگی نمی تواند بزرگتر از تاریخ امروز باشد ", "خطا ", MessageBoxButtons.OK, MessageBoxIcon.Error);
               // }
           
            int year, month, day,y,m,d,nm=0,temp=0,days=0;//nm: number of month
            PersianCalendar pc = new PersianCalendar();
            year = pc.GetYear(dt);
            month=pc.GetMonth(dt);
            day=pc.GetDayOfMonth(dt);

            y = pc.GetYear(DateTime.Now);
            m = pc.GetMonth(DateTime.Now);
            d = pc.GetDayOfMonth(DateTime.Now);
            Boolean kabise = false;
            int[] kabiseNumber = { 1,5,9,13,17,22,26,30};

            for (int i = 0; i < 8 && !kabise; i++)
                if (y % 33 == kabiseNumber[i] || year % 33 == kabiseNumber[i])
                    kabise = true;

            /*********  weak of obstetric      *******/
            if (month <= m)
                nm = m - month;
            else
                nm = 12 - month + m;
            temp = month;
            if (month < 7)
                days = 31 - day;
            else if (month < 12)
                days = 30 - day;
            else//kabise
            {
                if ( kabise)
                    days = 30 - day;
                else
                    days = 29 - day;
            }
            

            if (nm <= 0)
            {
                nm = 1;
                days = d-day;

            }else
                 days += d;

            nm--;
            while (nm!=0)
            {
                nm--;
                if (temp < 7)
                    days += 31;
                else if (temp < 12)
                    days += 30;
                else
                {
                    if (kabise)
                        days += 30;
                    else
                        days += 29;
                }
                temp++;
                if (temp > 12)
                    temp = 1;
            }
           
          /****************** ga *************************/  
            if (month < 7)
            {
                month += 9;
                day += 7;
               
                if (month > 12)
                {
                    year++;
                    month -= 12;
                }

                if (month < 7 && day > 31)
                {
                    day -= 31;
                    month++;
                }
               if (month > 6 && month!=12 && day > 30)
                {
                    day -= 30;
                    month++;
                }
               
                
                if (month == 12 && day > 29 && !kabise)
                {
                    day -= 29;
                    month++;
                }
                if (month == 12 && day > 30 && kabise)
                {
                    day -= 30;
                    month++;
                }
                if (month > 12)
                {
                    year++;
                    month -= 12;
                }
            }
            else
            {
                month -= 3;
                day += 7;
                if (month < 7 && day > 31)
                {
                    day -= 31;
                    month++;
                }
                if (month > 6 && month != 12 && day > 30)
                {
                    day -= 30;
                    month++;
                }

                if (month == 12 && day > 29 && !kabise)
                {
                    day -= 29;
                    month++;
                }
                if (month == 12 && day > 30 && kabise)
                {
                    day -= 30;
                    month++;
                }
             
                year++;
            }
            resultLmp.Text = year + "/" + month + "/" + day + "  تاریخ تقریبی زایمان "; 
            day=days%7;
            temp=days/7;//weak
            resultWeak1.Text = " هفته بارداری "+(day == 0 ? temp + "" : temp + 1 + "");
            resultWeakLpm.Text = " از زمان بارداری " + temp + " هفته " + day + " روز گذشته است ";
            sumday.Text = " روز " + days;
            temp=days;
            if (temp <= 30)
                lblMonth.Text = " ماه اول";
            else if (temp <= 60)
                lblMonth.Text = " ماه دوم";
            else if (temp <= 90)
                lblMonth.Text = " ماه سوم";
            else if (temp <= 120)
                lblMonth.Text = " ماه چهارم";
            else if (temp <= 150)
                lblMonth.Text = " ماه پنجم";
            else if (temp <= 180)
                lblMonth.Text = " ماه ششم";
            else if (temp <= 210)
                lblMonth.Text = " ماه هفتم";
            else if (temp <= 240)
                lblMonth.Text = " ماه هشتم";
            else if (temp <= 270)
                lblMonth.Text = " ماه نهم";
            else
                lblMonth.Text = "ماه نامعتبر";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime? dt1 = datepikerlab.Value;
            DateTime dt;
            
            dt = dt1.Value;
            if (dt.Date.CompareTo(DateTime.Now) > 0)
                MessageBox.Show(" تاریخ آزمایش سونوگرافی نمی تواند بزرگتر از تاریخ امروز باشد ", "خطا ", MessageBoxButtons.OK, MessageBoxIcon.Error);
          

            int year, month, day, y, m, d, nm = 0, temp = 0, days = 0;//nm: number of month
            PersianCalendar pc = new PersianCalendar();
            year = pc.GetYear(dt);
            month = pc.GetMonth(dt);
            day = pc.GetDayOfMonth(dt);

            y = pc.GetYear(DateTime.Now);
            m = pc.GetMonth(DateTime.Now);
            d = pc.GetDayOfMonth(DateTime.Now);
            Boolean kabise = false;
            int[] kabiseNumber = { 1, 5, 9, 13, 17, 22, 26, 30 };

            for (int i = 0; i < 8 && !kabise; i++)
                if (y % 33 == kabiseNumber[i] || year % 33 == kabiseNumber[i])
                    kabise = true;

            /*********  فاصله بین دو تاریخ سونوگرافی تا الان      *******/
            if (month <= m)
                nm = m - month;
            else
                nm = 12 - month + m;
            temp = month;
            if (month < 7)
                days = 31 - day;
            else if (month < 12)
                days = 30 - day;
            else//kabise
            {
                if (kabise)
                    days = 30 - day;
                else
                    days = 29 - day;
            }


            if (nm <= 0)
            {
                nm = 1;
                days = d - day;

            }
            else
                days += d;

            nm--;
            while (nm != 0)
            {
                nm--;
                if (temp < 7)
                    days += 31;
                else if (temp < 12)
                    days += 30;
                else
                {
                    if (kabise)
                        days += 30;
                    else
                        days += 29;
                }
                temp++;
                if (temp > 12)
                    temp = 1;
            }

            /****************** ga *************************/
            int w, r;//weak and day
            w = selectWeak.SelectedIndex;
            w++;
            r = selectDay.SelectedIndex;
            days = days + (w * 7) + r;//days2
            
            day = days % 7;//day
            temp =days / 7;//weak
            resultw.Text = " هفته بارداری " + (day == 0 ? temp + "" : temp + 1 + "");
            resultw2.Text = " از زمان بارداری " + temp + " هفته " + day + " روز گذشته است ";
            resultday.Text = " روز " + days;
            temp = days;

            if (temp <= 30)
                resultmonth.Text = " ماه اول";
            else if (temp <= 60)
                resultmonth.Text = " ماه دوم";
            else if (temp <= 90)
                resultmonth.Text = " ماه سوم";
            else if (temp <= 120)
                resultmonth.Text = " ماه چهارم";
            else if (temp <= 150)
                resultmonth.Text = " ماه پنجم";
            else if (temp <= 180)
                resultmonth.Text = " ماه ششم";
            else if (temp <= 210)
                resultmonth.Text = " ماه هفتم";
            else if (temp <= 240)
                resultmonth.Text = " ماه هشتم";
            else if (temp <= 270)
                resultmonth.Text = " ماه نهم";
            else
                resultmonth.Text = "ماه نامعتبر";


            //تاریخ تقریبی زایمان
            temp = 270 - days;
           
            while (temp > 0)
            {
                if (m < 7)
                {
                    day = temp % 31;
                    month = temp / 31;
                    year=31;//temp variable
                }
                else if (m > 6 && m != 12)
                {
                    day = temp % 30;
                    month = temp / 30;
                    year=30;
                }
                else if (kabise)
                {
                    day = temp % 30;
                    month = temp / 30;
                    year=30;
                }
                else if (!kabise)
                {
                    day = temp % 29;
                    month = temp / 29;
                    year=29;
                }
                if (month == 0)
                {
                    temp -= day;
                    day = d + day;
                }
                else 
                {
                    day =d+year;
                    temp -= year;
                }
               
                
                if (m < 7 && day > 31)
                {
                    day -= 31;
                    m++;
                    if (m == 7 && day == 31)
                    {
                        m++;
                        day -= 30;
                    }
                }
                if (m > 6 && m != 12 && day > 30)
                {
                    day -= 30;
                    m++;
                }

                if (m == 12 && day > 29 && !kabise)
                {
                    day -= 29;
                    m++;
                }
                if (m == 12 && day > 30 && kabise)
                {
                    day -= 30;
                    m++;
                }

                if (m > 12)
                {
                    m = 1;
                    y++;
                }
               
            }
           
            
            reultsono.Text = y + "/" + m + "/" + day + "  تاریخ تقریبی زایمان ";

        }

       
       
        
    }
}
