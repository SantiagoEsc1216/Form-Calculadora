﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//:TODO
// Recuperar operacion del historial
// Bug: Usar 2 veces seguidas un operador no concatena las operacione

namespace Actividad_Calculadora
{
    public partial class Fondo : Form
    {
        float First_num; //Almacenara el primer numero ingresado 
        bool First_Data=false; //Sirve para saber si ya se ingreso el primer numero o no 
        float Second_num;
        bool Second_Data=false;
        string Operation;
        int Operation_Key;
        float Result;
        bool Result_Data = false;
        bool buffer = false; //Hay una serie de operaciones anteriores

        public Fondo()
        {
            InitializeComponent();
        }

        private void delete_click(object sender, EventArgs e)
        {
            //Boton de delete 
            //Le di click sin querer antes de cambiar el nombre:( 
            // Expecion: borrar en blanco
            if(TextBoard.Text.Length > 0)
            {
                TextBoard.Text = TextBoard.Text.Remove(TextBoard.Text.Length - 1);
            }
        }

        private void division_click(object sender, EventArgs e)
        {
            
            //Boton de division xd
            //Primera vez que se presiona el boton asigna el valor
            Assing_number();
            Binary_Option();
            Assing_number();
            Binary_Option();
            //Asignar el simbolo
            Operation = "/";
            Operation_Key = 4;
            operation_label.Text = First_num + " " + Operation;
            buffer = false;

        }

        private void result_click(object sender, EventArgs e)
        {
            //Este es el igual pero le di click antes de cambiarle el nombre:(((
            Assing_number();
            Binary_Option();
            buffer = true;
        }
        //Funcion que asignara el valor a las variables cada vez que es presionado un boton de operador
        public void Assing_number()
        {
            if (Result_Data)
            {
                First_num = Result;
                First_Data = true;
            }
            else
            {
                if (!First_Data) //Primer numero no tiene valor 
                {
                    //Convertir de cadena a numero

                    if (!(float.TryParse(TextBoard.Text, out First_num)))
                    {
                        MessageBox.Show("No se pueden ingresar letras");
                    }
                    else
                    {
                        //Dato guardado correctamente
                        First_Data = true;
                        TextBoard.Clear();
                    }
                }
                else if (!Second_Data)
                {
                    if (!(float.TryParse(TextBoard.Text, out Second_num)))
                    {
                        //MessageBox.Show("No se pueden ingresar letras");
                    }
                    else
                    {
                        //Dato correctamente
                        Second_Data = true;
                        TextBoard.Clear();

                    }
                }
            }
            
           // TextBoard.Clear();
        }
        public void Write(int num)
        {
            //Concatena los numeros en el cuadro de texto
            if (buffer)
            {
                clear();
            }
            else if(Result_Data)
            {
                TextBoard.Clear();
                Result_Data = false;
            }
            TextBoard.Text = TextBoard.Text + num;
        }
        public void Write(string str)
        {
            if (buffer)
            {
                clear();
            }
            else if (Result_Data)
            {
                TextBoard.Clear();
                Result_Data = false;
            }
            TextBoard.Text = TextBoard.Text + str;
        }

        private void Number_0_Click(object sender, EventArgs e)
        {
            Write(0);
        }

        private void Number_1_Click(object sender, EventArgs e)
        {
            Write(1);
        }

        private void Number_2_Click(object sender, EventArgs e)
        {
            Write(2);
        }

        private void Number_3_Click(object sender, EventArgs e)
        {
            Write(3);
        }

        private void Number_4_Click(object sender, EventArgs e)
        {
            Write(4);
        }

        private void Number_5_Click(object sender, EventArgs e)
        {
            Write(5);
        }

        private void Number_6_Click(object sender, EventArgs e)
        {
            Write(6);
        }

        private void Number_7_Click(object sender, EventArgs e)
        {
            Write(7);
        }

        private void Number_8_Click(object sender, EventArgs e)
        {
            Write(8);
        }

        private void Number_9_Click(object sender, EventArgs e)
        {
            Write(9);
        }

        private void point_Click(object sender, EventArgs e)
        {
            Write(".");
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            clear();
        }
        private void clear()
        {
            TextBoard.Clear();
            operation_label.Text = string.Empty;
            First_Data = false;
            Second_Data = false;
            Result_Data = false;
        }
        public void Sent_To_History(float First, string Ope, float Second, float Result)
        {
            //Funcion que enviara los datos al historial para que se guarden 
            History.Items.Add(First + " " + Ope + " " + Second + " = " + Result);
        }
        public void Binary_Option()
        {
            //Funcion que hara las acciones del igual
            //Es decir, leera el caracter de la operacion, y despues la ejecutara
            bool Execute_Operation = false;
            if (First_Data && Second_Data)
            {
                switch (Operation_Key)
                {
                    case 1:
                        Result = First_num + Second_num;
                        Result_Data = true;
                        Execute_Operation = true;
                        break;
                    case 2:
                        Result = First_num - Second_num;
                        Result_Data = true;
                        Execute_Operation = true;
                        break;
                    case 3:
                        Result = First_num * Second_num;
                        Result_Data = true;
                        Execute_Operation = true;
                        break;
                    case 4:
                        if (Second_num == 0)
                        {
                            MessageBox.Show("NO SE PUEDE DIVIDIR ENTRE 0");
                            TextBoard.Clear();
                        }
                        else
                        {
                            Result = First_num / Second_num;
                            Result_Data = true;
                            Execute_Operation = true;
                        }

                        break;


                }
                //Enviar los datos al historial
                if (Execute_Operation == true)
                {
                    Sent_To_History(First_num, Operation, Second_num, Result);
                }

                //Ahora el primer dato es el resultado
                First_num = Result;
                operation_label.Text = operation_label.Text + " " + " " + Second_num + " =";
                Second_num = 0;
                First_Data = false;
                Second_Data = false;
                TextBoard.Text = Result.ToString();
            }

        }
        private void Sum_Click(object sender, EventArgs e)
        {
            
            //Primera vez que se presiona el boton asigna el valor
            Assing_number();
            Binary_Option();
            Assing_number();
            Binary_Option();
            //Asignar el simbolo
            Operation = "+";
            Operation_Key = 1;
            operation_label.Text = First_num + " " + Operation;
            buffer = false;

        }

        private void Res_Click(object sender, EventArgs e)
        {
            
            //Primera vez que se presiona el boton asigna el valor
            Assing_number();
            Binary_Option();
            Assing_number();
            Binary_Option();

            //Asignar el simbolo
            Operation = "-";
            Operation_Key = 2;
            operation_label.Text = First_num + " " + Operation;
            buffer = false;
        }

        private void Mult_Click(object sender, EventArgs e)
        {
           
            //Primera vez que se presiona el boton asigna el valor
            Assing_number();
            Binary_Option();
            Assing_number();
            Binary_Option();
            //Asignar el simbolo
            Operation = "*";
            Operation_Key = 3;
            operation_label.Text = First_num + " " + Operation;
            buffer = false;
        }

        private void Memory_Click(object sender, EventArgs e)
        {
            ListOfMemory.Items.Add(TextBoard.Text);
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TextBoard_TextChanged(object sender, EventArgs e)
        {

        }

        private void ListOfMemory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListOfMemory.SelectedIndex >= 0)
            {
                TextBoard.Text = ListOfMemory.Items[ListOfMemory.SelectedIndex].ToString();
                if (!First_Data)
                {
                    float.TryParse(ListOfMemory.Items[ListOfMemory.SelectedIndex].ToString(), out First_num);
                }
                else
                {
                    float.TryParse(ListOfMemory.Items[ListOfMemory.SelectedIndex].ToString(), out Second_num);
                    Second_Data = true;
                }
            }
        }

        private void History_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Recuperar operacion
            string op = History.Items[History.SelectedIndex].ToString();
            string[] elements = op.Split(' ');

            float.TryParse(elements[0], out First_num);
            Operation = elements[1];
            float.TryParse(elements[2], out Second_num);
            float.TryParse(elements[4], out Result);

            operation_label.Text = First_num + " " + Operation + " " + Second_num +" =";
            TextBoard.Text = Result.ToString();

            First_Data = true;
            First_num = Result;
            Result_Data = true;
            Second_Data = false;
            
        }
    }
}
