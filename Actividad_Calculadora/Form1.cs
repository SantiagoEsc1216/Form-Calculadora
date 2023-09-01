using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Actividad_Calculadora
{
    public partial class Fondo : Form
    {
        int First_num; //Almacenara el primer numero ingresado 
        bool First_Data=false; //Sirve para saber si ya se ingreso el primer numero o no 
        int Second_num;
        bool Second_Data=false;
        string Operation;
        int Operation_Key;
        int Result;
        bool Result_Data = false;

        public Fondo()
        {
            InitializeComponent();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //Boton de delete 
            //Le di click sin querer antes de cambiar el nombre:( 
            TextBoard.Text= TextBoard.Text.Remove(TextBoard.Text.Length-1);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //Boton de division xd
            //Primera vez que se presiona el boton asigna el valor
            Assing_number();
            Binary_Option();
            //Asignar el simbolo
            Operation = "/";
            Operation_Key = 4;
            
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //Este es el igual pero le di click antes de cambiarle el nombre:(((
            Assing_number();
            Binary_Option();

        }
        //Funcion que asignara el valor a las variables cada vez que es presionado un boton de operador
        public void Assing_number()
        {
           
            if(!First_Data) //Primer numero no tiene valor 
            {
                //Convertir de cadena a numero
                
                if (!(int.TryParse(TextBoard.Text, out First_num)))
                {
                    MessageBox.Show("No se pueden ingresar letras");
                }
                else
                {
                    //Dato guardado correctamente
                 
                    First_Data = true;
                }
            }
            else if(!Second_Data)
            {
                if(!(int.TryParse(TextBoard.Text, out Second_num)))
                {
                    MessageBox.Show("No se pueden ingresar letras");
                }
                else
                {
                    //Dato correctamente
                    Second_Data = true;
                   
                }
            }
            Result_Data = false;
            TextBoard.Clear();
        }
        public void Write_Number(int num)
        {
            //Concatena los numeros en el cuadro de texto
            if(Result_Data)
            {
                TextBoard.Clear();
            }
            TextBoard.Text= TextBoard.Text.ToString()+ num;
        }
        private void Number_0_Click(object sender, EventArgs e)
        {
            Write_Number(0);
        }

        private void Number_1_Click(object sender, EventArgs e)
        {
            Write_Number(1);
        }

        private void Number_2_Click(object sender, EventArgs e)
        {
            Write_Number(2);
        }

        private void Number_3_Click(object sender, EventArgs e)
        {
            Write_Number(3);
        }

        private void Number_4_Click(object sender, EventArgs e)
        {
            Write_Number(4);
        }

        private void Number_5_Click(object sender, EventArgs e)
        {
            Write_Number(5);
        }

        private void Number_6_Click(object sender, EventArgs e)
        {
            Write_Number(6);
        }

        private void Number_7_Click(object sender, EventArgs e)
        {
            Write_Number(7);
        }

        private void Number_8_Click(object sender, EventArgs e)
        {
            Write_Number(8);
        }

        private void Number_9_Click(object sender, EventArgs e)
        {
            Write_Number(9);
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            TextBoard.Clear();
        }

        public void Sent_To_History(int First, string Ope, int Second,int Result)
        {
            //Funcion que enviara los datos al historial para que se guarden 
            History.Items.Add(First+" "+ Ope +" "+ Second + " = " + Result);
        }
        public void Binary_Option()
        {
            //Funcion que hara las acciones del igual
            //Es decir, leera el caracter de la operacion, y despues la ejecutara
            if (First_Data && Second_Data)
            {
                switch (Operation_Key)
                {
                    case 1:
                        Result = First_num + Second_num;
                        Result_Data = true;
                        break;
                    case 2:
                        Result= First_num - Second_num;
                        Result_Data = true;
                        break;
                    case 3:
                        Result = First_num * Second_num;
                        Result_Data = true;
                        break;
                    case 4:
                        Result = First_num / Second_num;
                        Result_Data = true;
                        break;


                }
                //Enviar los datos al historial
                Sent_To_History(First_num,Operation,Second_num,Result);
                //Ahora el primer dato es el resultado
                First_num = Result;
                Second_num = 0;
                First_Data= false;
                Second_Data = false;
                TextBoard.Text = Result.ToString();
            }
            
        }
        private void Sum_Click(object sender, EventArgs e)
        {
            //Primera vez que se presiona el boton asigna el valor
            Assing_number();
            Binary_Option();
            //Asignar el simbolo
            Operation = "+";
            Operation_Key = 1;
            
        }

        private void Res_Click(object sender, EventArgs e)
        {
            //Primera vez que se presiona el boton asigna el valor
            Assing_number();
            Binary_Option();
            //Asignar el simbolo
            Operation = "-";
            Operation_Key= 2;
            
        }

        private void Mult_Click(object sender, EventArgs e)
        {
            //Primera vez que se presiona el boton asigna el valor
            Assing_number();
            Binary_Option();
            //Asignar el simbolo
            Operation = "*";
            Operation_Key = 3;
            
        }

        private void Memory_Click(object sender, EventArgs e)
        {
            ListOfMemory.Items.Add(TextBoard.Text);
        }

        private void ListOfMemory_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoard.Text = ListOfMemory.Items[ListOfMemory.SelectedIndex].ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TextBoard_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
