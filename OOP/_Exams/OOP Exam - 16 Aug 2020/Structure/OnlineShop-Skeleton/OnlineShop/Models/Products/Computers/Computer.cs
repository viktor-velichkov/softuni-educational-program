using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
                    : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => this.components.AsReadOnly();


        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.AsReadOnly();

        public override double OverallPerformance
        {
            get
            {
                if (this.Components.Count == 0)
                {
                    return base.OverallPerformance;
                }
                else
                {
                    return base.OverallPerformance + this.Components.Select(c => c.OverallPerformance).Average();
                }
            }
        }
        public override decimal Price => base.Price
                                         + this.Components.Select(x => x.Price).Sum()
                                         + this.Peripherals.Select(x => x.Price).Sum();

        public void AddComponent(IComponent component)
        {
            string givenComponentType = component.GetType().Name;
            if (this.components.Select(x => x.GetType().Name).Contains(givenComponentType))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingComponent,
                                                            givenComponentType,
                                                            this.GetType().Name,
                                                            this.Id));
            }
            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            string givenPeripheralType = peripheral.GetType().Name;
            if (this.peripherals.Select(x => x.GetType().Name).Contains(givenPeripheralType))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingPeripheral,
                                                            givenPeripheralType,
                                                            this.GetType().Name,
                                                            this.Id));
            }
            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (this.components.Count == 0 || !this.Components.Select(x => x.GetType().Name).Contains(componentType))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingComponent,
                                                            componentType,
                                                            this.GetType().Name,
                                                            this.Id));
            }
            IComponent componentToRemove = this.components.FirstOrDefault(x => x.GetType().Name == componentType);
            this.components.Remove(componentToRemove);
            return componentToRemove;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (this.peripherals.Count == 0 || !this.Peripherals.Select(x => x.GetType().Name).Contains(peripheralType))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingPeripheral,
                                                            peripheralType,
                                                            this.GetType().Name,
                                                            this.Id));
            }
            IPeripheral peripheralToRemove = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            this.peripherals.Remove(peripheralToRemove);
            return peripheralToRemove;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.AppendLine($" Components ({this.Components.Count}):");
            foreach (var component in this.Components)
            {
                result.AppendLine($"  {component.ToString()}");
            }
            double avgPeripheralPerformance = 0;
            if (this.Peripherals.Count!=0)
            {
                avgPeripheralPerformance = this.Peripherals.Select(x => x.OverallPerformance).Average();
            }
            result.AppendLine($" Peripherals ({this.Peripherals.Count}); Average Overall Performance ({avgPeripheralPerformance:f2}):");
            foreach (var peripheral in this.Peripherals)
            {
                result.AppendLine($"  {peripheral.ToString()}");
            }
            return result.ToString().Trim();
        }
    }
}
