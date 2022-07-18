using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IPeripheral> peripherals;
        private List<Models.Products.Components.IComponent> components;
        public Controller()
        {
            this.computers = new List<IComputer>();
            this.peripherals = new List<IPeripheral>();
            this.components = new List<Models.Products.Components.IComponent>();
        }
        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            
            ValidateComputerId(computerId);
            var component = CreateComponent(componentType, id, manufacturer, model, price, overallPerformance, generation);
            if (this.components.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }
            else if (component == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);
            computer.AddComponent(component);
            this.components.Add(component);
            return String.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer computer = CreateComputer(computerType, id, manufacturer, model, price);
            if (this.computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }
            else if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }
            this.computers.Add(computer);
            return String.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {            
            ValidateComputerId(computerId);
            IPeripheral peripheral = CreatePeripheral(peripheralType, id, manufacturer, model, price, overallPerformance, connectionType);
            if (this.peripherals.Any(x=>x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }
            else if (peripheral == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }
            IComputer computer = this.computers.FirstOrDefault(x => x.Id == computerId);
            computer.AddPeripheral(peripheral);
            this.peripherals.Add(peripheral);
            return String.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            if (this.computers.Count==0||this.computers.All(x=>x.Price>budget))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }
            IComputer boughtComputer = this.computers.Where(c => c.Price <= budget).OrderByDescending(x => x.OverallPerformance).First();
            this.computers.Remove(boughtComputer);
            return boughtComputer.ToString();
        }

        public string BuyComputer(int id)
        {
            ValidateComputerId(id);
            IComputer computer = this.computers.FirstOrDefault(x => x.Id == id);
            this.computers.Remove(computer);
            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            ValidateComputerId(id);
            IComputer computer = this.computers.FirstOrDefault(x => x.Id==id);
            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            ValidateComputerId(computerId);
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);
            var component = computer.RemoveComponent(componentType);
            this.components.Remove(component);
            return String.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            ValidateComputerId(computerId);
            IComputer computer = this.computers.FirstOrDefault(x => x.Id == computerId);
            IPeripheral peripheral = computer.RemovePeripheral(peripheralType);
            this.peripherals.Remove(peripheral);
            return String.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);
        }
        public void Close()
        {
            Environment.Exit(0);
        }

        private void ValidateComputerId(int computerId)
        {
            if (this.computers.All(c => c.Id != computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }

        private IComputer CreateComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer computer;
            switch (computerType)
            {
                case "DesktopComputer":
                    computer = new DesktopComputer(id, manufacturer, model, price);
                    break;
                case "Laptop":
                    computer = new Laptop(id, manufacturer, model, price);
                    break;
                default:
                    computer = null;
                    break;
            }
            return computer;
        }
        private Models.Products.Components.IComponent CreateComponent(string componentType, int id, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            OnlineShop.Models.Products.Components.IComponent component;
            switch (componentType)
            {
                case "CentralProcessingUnit":
                    component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "Motherboard":
                    component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "PowerSupply":
                    component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "RandomAccessMemory":
                    component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "SolidStateDrive":
                    component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "VideoCard":
                    component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                default:
                    component = null;
                    break;
            }
            return component;
        }

        private IPeripheral CreatePeripheral(string peripheralType, int id, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            IPeripheral peripheral;
            switch (peripheralType)
            {
                case "Headset":
                    peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Keyboard":
                    peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Monitor":
                    peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Mouse":
                    peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                default:
                    peripheral = null;
                    break;
            }
            return peripheral;
        }
    }
}
