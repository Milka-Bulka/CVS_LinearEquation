﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW_Equation
{
    public class LinearEquation
    {
        List<float> coefficients = new List<float>();
        public int Size => coefficients.Count;

        /// <summary>
        /// Конструирует уравнение вида aN*x + coefficients[0]y + ... + coefficients[N-2]z + coefficients[N-1] = 0
        /// </summary>
        /// 
        /// Примеры:
        /// <example>
        /// LinearEquation(1,2,3,4) => 1x + 2y + 3z + 4 = 0
        /// LinearEquation(1,2) => 1x + 2 = 0
        /// LinearEquation(1) => 1 = 0 (не имеет решений)
        /// </example>
        /// 
        /// <param name="aN">Последний коэффициент</param>
        /// <param name="coefficients">Остальные коэффициенты</param>
        public LinearEquation(params float[] coefficients)
        {
            this.coefficients.AddRange(coefficients);
        }
        public LinearEquation(List<float> coefficients)
        {
            this.coefficients = coefficients;
        }
        /// <summary>
        /// Суммирует свободный член first с second
        /// </summary>
        static public LinearEquation operator +(LinearEquation first, float second)
        {
            LinearEquation equation = first;
            equation.coefficients[equation.Size - 1] += second;
            return equation;
        }
        /// <summary>
        /// Вычитает second из свободного члена first
        /// </summary>
        static public LinearEquation operator -(LinearEquation first, float second)
        {
            LinearEquation equation = first;
            equation.coefficients[equation.Size - 1] -= second;
            return equation;
        }
        public override bool Equals(object obj)
        {
            if (obj is LinearEquation equation)
            {
                if (Size != equation.Size)
                    return false;
                for (int i = 0; i < Size; i++)
                {
                    if (this.coefficients[i] != equation.coefficients[i])
                        return false;
                }
                return true;
            }
            return false;
        }
        static public bool operator ==(LinearEquation first, LinearEquation second)
        {
            return first.Equals(second);
        }
        static public bool operator !=(LinearEquation first, LinearEquation second)
        {
            return !first.Equals(second);
        }
        public float this[int i]
        {
            get { return coefficients[i]; }
            set { coefficients[i] = value; }
        }
        static public LinearEquation operator -(LinearEquation first, LinearEquation second)
        {
            if (first.Size != second.Size)
                throw new IndexOutOfRangeException("Разная размерность");
            List<float> result= new List<float>();
            for (int i = 0; i < second.Size; i++)
            {
                result.Add(first[i] - second[i]);
            }
            return new LinearEquation(result);
        }
        static public LinearEquation operator +(LinearEquation first, LinearEquation second)
        {
            if (first.Size != second.Size)
                throw new IndexOutOfRangeException("Разная размерность");
            List<float> result = new List<float>();
            for (int i = 0; i < second.Size; i++)
            {
                result.Add(first[i] + second[i]);
            }
            return new LinearEquation(result);
        }
        static public implicit operator bool(LinearEquation first)
        {
            int last = first.Size - 1;
            if (first[last] == 0)
                return true;
            else
            {
                for (int i = 0; i < last; i++)
                {
                    if (first[i] != 0)
                        return true;
                }
                return false;
            }
        }
        static public float answer(LinearEquation first)
        {
            int last = first.Size - 1;
            if (first[last] == 0)
                return 0;
            float result = -first[1]/first[0];
            return result;
        }
        static public string ToString(LinearEquation first)
        {
            string[] symbol = new string[] { "x", "y", "z" };
            string str = "";
            for (int i = 0; i < first.Size-1; i++)
            {
                str = first[i] + symbol[i] + " + "; 
            }
            str += first[first.Size - 1] + " = 0";
            return str;
        }
        static public LinearEquation Rand(LinearEquation first)
        {
            Random rand = new Random();
            List<float> result = new List<float>();
            for (int i = 0; i < first.Size; i++)
            {
                int a = rand.Next(20);
                result.Add(a);
            }
            return new LinearEquation(result);
        }
        static public LinearEquation Same_value(LinearEquation first)
        {
            Random rand = new Random();
            int a = rand.Next(20);
            List<float> result = new List<float>();
            for (int i = 0; i < first.Size; i++)
            {
                result.Add(a);
            }
            return new LinearEquation(result);
        }
        static public LinearEquation Multi(LinearEquation first, float b)
        {
            List<float> result = new List<float>();
            for (int i = 0; i < first.Size; i++)
            {
                result.Add(first[i]*b);
            }
            return new LinearEquation(result);
        }
    }
}
