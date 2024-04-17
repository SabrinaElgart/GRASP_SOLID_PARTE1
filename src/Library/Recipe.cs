//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
            Console.WriteLine($"El costo total es: ${this.GetProductionCost()}"); //Se agrega al final de la impresión de la receta el costo total de producción que se obtiene usando el método recién agregado.
        }
        public double GetProductionCost() //defino método GetProductionCost()
        {
            double TotalCost = 0; //declaro variable, la cual se utiliza para acumular el costo total
            foreach(Step step in this.steps)
            {
                TotalCost += step.Quantity*step.Input.UnitCost + step.Time*step.Equipment.HourlyCost/60; //se calcula costo total, lo divido para convertirlo en horas.
            }
            return TotalCost;
        }
    }
}
/* 
El patrón utilizado en este caso es Expert. 
Ya que la clase que tiene toda la información para calcular el costo total es la clase Recipe (la clase
experta en la información que se necesita). Es la clase que conoce todos los steps de la receta, 
pudiendo a partir de esto extraer los costos para cada equipamiento y productos.
En conclusión, es la única clase que conoce todos los pasos de la receta, entonces es la que 
puede calcular el costo total.
*/