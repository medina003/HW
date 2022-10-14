using System.Text.Json;
namespace WinFormsHW1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                textBox1.Text = "1,00";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                textBox1.Text = "2,00";
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                textBox1.Text = "2,30";
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                textBox1.Text = "0,80";
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                textBox1.Text = "0,40";
            }
            if (textBox2.Text != "" && !textBox3.Enabled)
            {
                float price;
                float litr;
                bool check1 = float.TryParse(textBox1.Text, out price);
                bool check2 = float.TryParse(textBox2.Text, out litr);
                if (check1 && check2)
                {
                    float total_price;
                    total_price = price * litr;
                    string total = Convert.ToString(total_price);
                    textBox4.Text = total;
                }
            }
            else if (textBox3.Text != "" && !textBox2.Enabled)
            {

                float priceofl;
                float sum;
                bool check1 = float.TryParse(textBox1.Text, out priceofl);
                bool check2 = float.TryParse(textBox3.Text, out sum);
                if (check1 && check2)
                {
                    float total_l;
                    total_l = sum / priceofl;
                    string total = Convert.ToString(total_l);
                    textBox4.Text = total;
                    groupBox3.Text = "Total volume:";
                    label6.Text = "l.";

                }

            }
        }



        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton2.Enabled = false;
            textBox3.Enabled = false;
            if (textBox2.Text != "" )
            {
                float price;
                float litr;
                bool check1 = float.TryParse(textBox1.Text, out price);
                bool check2 = float.TryParse(textBox2.Text, out litr);
                if (check1 && check2)
                {
                    float total_price;
                    total_price = price * litr;
                    string total = Convert.ToString(total_price);
                    textBox4.Text = total;
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Enabled = false;
            textBox2.Enabled = false;
            if (textBox3.Text !="")
            {

                float priceofl;
                float sum;
                bool check1 = float.TryParse(textBox1.Text, out priceofl);
                bool check2 = float.TryParse(textBox3.Text, out sum);
                if (check1 && check2)
                {
                    float total_l;
                    total_l =  sum / priceofl;
                    string total = Convert.ToString(total_l);
                    textBox4.Text = total;
                    groupBox3.Text = "Total volume:";
                    label6.Text = "l.";

                }

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!textBox3.Enabled)
            {

                float price;
                float litr;
                bool check1 = float.TryParse(textBox1.Text, out price);
                bool check2 = float.TryParse(textBox2.Text, out litr);
                if (check1 && check2)
                {
                    float total_price;
                    total_price = price * litr;
                    string total = Convert.ToString(total_price);
                    textBox4.Text = total;
                }

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            if (!textBox2.Enabled)
            {

                float priceofl;
                float sum;
                bool check1 = float.TryParse(textBox1.Text, out priceofl);
                bool check2 = float.TryParse(textBox3.Text, out sum);
                if (check1 && check2)
                {
                    float total_l;
                    total_l = sum / priceofl;
                    string total = Convert.ToString(total_l);
                    textBox4.Text = total;
                    groupBox3.Text = "Total volume:";
                    label6.Text = "l.";
                }

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (textBox12.Text != "" && checkBox1.Checked)
            {
                float hotdogsum = MiniCafeService.hot_dog_check(textBox12.Text);
                float hamburgersum = 0, friessum = 0, cocacolasum = 0,total_price = 0 ;
                if (textBox11.Text != "" && checkBox2.Checked) {  hamburgersum = MiniCafeService.hamburger_check(textBox11.Text); total_price += hamburgersum; }
                if (textBox10.Text != "" && checkBox3.Checked) {  friessum = MiniCafeService.fries_check(textBox10.Text); total_price += friessum; }
                if (textBox9.Text != "" && checkBox4.Checked) {  cocacolasum = MiniCafeService.cocacola_check(textBox9.Text);total_price += cocacolasum; }
                total_price += hotdogsum;
                textBox13.Text = Convert.ToString(total_price);
            }
            if( !checkBox1.Checked)
            {
                if (textBox12.Text == "") { textBox12.Text = "0"; }
                float hamburgersum = 0, friessum = 0, cocacolasum = 0, total_price = 0;
                if (textBox11.Text != "" && checkBox2.Checked) { hamburgersum = MiniCafeService.hamburger_check(textBox11.Text); total_price += hamburgersum; }
                if (textBox10.Text != "" && checkBox3.Checked) { friessum = MiniCafeService.fries_check(textBox10.Text); total_price += friessum; }
                if (textBox9.Text != "" && checkBox4.Checked) { cocacolasum = MiniCafeService.cocacola_check(textBox9.Text); total_price += cocacolasum; }
                textBox13.Text = Convert.ToString(total_price);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox11.Text != "" && checkBox2.Checked)
            {
                float hamburgersum = MiniCafeService.hamburger_check(textBox11.Text);
                float hotdogsum = 0, friessum = 0, cocacolasum = 0, total_price = 0;
                if (textBox12.Text != "" && checkBox1.Checked) { hotdogsum = MiniCafeService.hot_dog_check(textBox12.Text); total_price += hotdogsum; }
                if (textBox10.Text != "" && checkBox3.Checked) { friessum = MiniCafeService.fries_check(textBox10.Text); total_price += friessum; }
                if (textBox9.Text != "" && checkBox4.Checked) { cocacolasum = MiniCafeService.cocacola_check(textBox9.Text); total_price += cocacolasum; }
                total_price += hamburgersum;
                textBox13.Text = Convert.ToString(total_price);
            }
            if (!checkBox2.Checked)
            {
                if (textBox11.Text == "") { textBox11.Text = "0"; }
                float hotdogsum = 0, friessum = 0, cocacolasum = 0, total_price = 0;
                if (textBox12.Text != "" && checkBox1.Checked) { hotdogsum = MiniCafeService.hot_dog_check(textBox12.Text); total_price += hotdogsum; }
                if (textBox10.Text != "" && checkBox3.Checked) { friessum = MiniCafeService.fries_check(textBox10.Text); total_price += friessum; }
                if (textBox9.Text != "" && checkBox4.Checked) { cocacolasum = MiniCafeService.cocacola_check(textBox9.Text); total_price += cocacolasum; }
                textBox13.Text = Convert.ToString(total_price);
            }

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox10.Text != "" && checkBox3.Checked)
            {
                float friessum = MiniCafeService.fries_check(textBox10.Text);
                float hotdogsum = 0, hamburgersum = 0, cocacolasum = 0, total_price = 0;
                if (textBox12.Text != "" && checkBox1.Checked) { hotdogsum = MiniCafeService.hot_dog_check(textBox12.Text); total_price += hotdogsum; }
                if (textBox11.Text != "" && checkBox2.Checked) { hamburgersum = MiniCafeService.hamburger_check(textBox11.Text); total_price += hamburgersum; }
                if (textBox9.Text != "" && checkBox4.Checked) { cocacolasum = MiniCafeService.cocacola_check(textBox9.Text); total_price += cocacolasum; }
                total_price += friessum;
                textBox13.Text = Convert.ToString(total_price);
            }
            if ( !checkBox3.Checked)
            {
                if(textBox10.Text == "") { textBox10.Text = "0"; }
                float hotdogsum = 0, hamburgersum = 0, cocacolasum = 0, total_price = 0;
                if (textBox12.Text != "" && checkBox1.Checked) { hotdogsum = MiniCafeService.hot_dog_check(textBox12.Text); total_price += hotdogsum; }
                if (textBox11.Text != "" && checkBox2.Checked) { hamburgersum = MiniCafeService.hamburger_check(textBox11.Text); total_price += hamburgersum; }
                if (textBox9.Text != "" && checkBox4.Checked) { cocacolasum = MiniCafeService.cocacola_check(textBox9.Text); total_price += cocacolasum; }
                textBox13.Text = Convert.ToString(total_price);
            }
        }
  
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox9.Text != "" && checkBox4.Checked)
            {
                float cocacolasum = MiniCafeService.cocacola_check(textBox9.Text);
                float hotdogsum = 0, hamburgersum = 0, friessum = 0, total_price = 0;
                if (textBox12.Text != "" && checkBox1.Checked) { hotdogsum = MiniCafeService.hot_dog_check(textBox12.Text); total_price += hotdogsum; }
                if (textBox11.Text != "" && checkBox2.Checked) { hamburgersum = MiniCafeService.hamburger_check(textBox11.Text); total_price += hamburgersum; }
                if (textBox10.Text != "" && checkBox3.Checked) { friessum = MiniCafeService.fries_check(textBox10.Text); total_price += friessum; }
                total_price += cocacolasum;
                textBox13.Text = Convert.ToString(total_price);
            }
            if ( !checkBox4.Checked)
            {
                if (textBox9.Text == "") { textBox9.Text = "0"; }
                float hotdogsum = 0, hamburgersum = 0, friessum = 0, total_price = 0;
                if (textBox12.Text != "" && checkBox1.Checked) { hotdogsum = MiniCafeService.hot_dog_check(textBox12.Text); total_price += hotdogsum; }
                if (textBox11.Text != "" && checkBox2.Checked) { hamburgersum = MiniCafeService.hamburger_check(textBox11.Text); total_price += hamburgersum; }
                if (textBox10.Text != "" && checkBox3.Checked) { friessum = MiniCafeService.fries_check(textBox10.Text); total_price += friessum; }
                textBox13.Text = Convert.ToString(total_price);
            }
        }

   



        private void button1_Click_1(object sender, EventArgs e)
        {
            float oil_total = 0;
            float meal_total = 0;
            bool check1 = false;
            if (radioButton1.Checked || radioButton2.Checked)
            {
                if (radioButton2.Checked) { check1 = float.TryParse(textBox3.Text, out oil_total); }
                else if (radioButton1.Checked) { check1 = float.TryParse(textBox4.Text, out oil_total); }
            }
            else check1 = true;
            bool check2 = float.TryParse(textBox13.Text, out meal_total);
            if (check1 && check2) {
                float sum = oil_total + meal_total; MiniCafeService.total_price += oil_total + meal_total; textBox14.Text = Convert.ToString(sum);
                bool flag = true;
                while (flag)
                {
                Thread.Sleep(3000);
                    DialogResult result =  MessageBox.Show(
                                "Do you want to erase existing data?",
                                "",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);
                if(result  == DialogResult.Yes) { comboBox1.SelectedIndex = 0; radioButton1.Checked = false; radioButton2.Checked = false;
                        radioButton1.Enabled = true; radioButton2.Enabled = true; textBox2.Enabled = true; textBox3.Enabled = true;
                        textBox2.Text = "0,00"; textBox3.Text = "0,00"; groupBox3.Text = "Total price:";textBox4.Text = "0,00";label6.Text = "azn.";
                        checkBox1.Checked = false; checkBox2.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false;
                        textBox12.Text = "0"; textBox11.Text = "0"; textBox10.Text = "0"; textBox9.Text = "0";textBox13.Text = "0,00";textBox14.Text = "0,00";
                        flag = false; }
                }
           
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked && textBox12.Text != "")
            {   float hamburgersum = 0, friessum = 0, cocacolasum = 0, total_price = 0;
                float hotdogsum = MiniCafeService.hot_dog_check(textBox12.Text);
                total_price += hotdogsum;
               
                if (textBox11.Text != "" && checkBox2.Checked) { hamburgersum = MiniCafeService.hamburger_check(textBox11.Text); total_price += hamburgersum; }
                if (textBox10.Text != "" && checkBox3.Checked) { friessum = MiniCafeService.fries_check(textBox10.Text); total_price += friessum; }
                if (textBox9.Text != "" && checkBox4.Checked) { cocacolasum = MiniCafeService.cocacola_check(textBox9.Text); total_price += cocacolasum; }
                textBox13.Text = Convert.ToString(total_price);

            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked && textBox11.Text != "")
            {
                float hamburgersum = MiniCafeService.hamburger_check(textBox11.Text);
                float hotdogsum = 0, friessum = 0, cocacolasum = 0, total_price = 0;
                if (textBox12.Text != "" && checkBox1.Checked) { hotdogsum = MiniCafeService.hot_dog_check(textBox12.Text); total_price += hotdogsum; }
                if (textBox10.Text != "" && checkBox3.Checked) { friessum = MiniCafeService.fries_check(textBox10.Text); total_price += friessum; }
                if (textBox9.Text != "" && checkBox4.Checked) { cocacolasum = MiniCafeService.cocacola_check(textBox9.Text); total_price += cocacolasum; }
                total_price += hamburgersum;
                textBox13.Text = Convert.ToString(total_price);
            }

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (textBox10.Text != "" && checkBox3.Checked)
            {
                float friessum = MiniCafeService.fries_check(textBox10.Text);
                float hotdogsum = 0, hamburgersum = 0, cocacolasum = 0, total_price = 0;
                if (textBox12.Text != "" && checkBox1.Checked) { hotdogsum = MiniCafeService.hot_dog_check(textBox12.Text); total_price += hotdogsum; }
                if (textBox11.Text != "" && checkBox2.Checked) { hamburgersum = MiniCafeService.hamburger_check(textBox11.Text); total_price += hamburgersum; }
                if (textBox9.Text != "" && checkBox4.Checked) { cocacolasum = MiniCafeService.cocacola_check(textBox9.Text); total_price += cocacolasum; }
                total_price += friessum;
                textBox13.Text = Convert.ToString(total_price);
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (textBox9.Text != "" && checkBox4.Checked)
            {
                float cocacolasum = MiniCafeService.cocacola_check(textBox9.Text);
                float hotdogsum = 0, hamburgersum = 0, friessum = 0, total_price = 0;
                if (textBox12.Text != "" && checkBox1.Checked) { hotdogsum = MiniCafeService.hot_dog_check(textBox12.Text); total_price += hotdogsum; }
                if (textBox11.Text != "" && checkBox2.Checked) { hamburgersum = MiniCafeService.hamburger_check(textBox11.Text); total_price += hamburgersum; }
                if (textBox10.Text != "" && checkBox3.Checked) { friessum = MiniCafeService.fries_check(textBox10.Text); total_price += friessum; }
                total_price += cocacolasum;
                textBox13.Text = Convert.ToString(total_price);
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
   
            MessageBox.Show(
                               $"Total revenue: {MiniCafeService.total_price} azn.",
                               "Exit",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
        }

    }
}