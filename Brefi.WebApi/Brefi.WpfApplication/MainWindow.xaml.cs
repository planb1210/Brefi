using Brefi.WpfApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
using Brefi.WpfApplication.Data;
using Brefi.WpfApplication.WebApi;
using System.Collections.ObjectModel;
using Autofac;
using Brefi.WpfApplication.Data.Repositories;

namespace Brefi.WpfApplication
{
    public partial class MainWindow : Window
    {
        private CatalogRepository catalogRepository;
        private BrendRepository brendRepository;
        private EquipmentRepository equipmentRepository;
        private ToolTypeRepository toolTypeRepository;
        private UpdateRepository updateRepository;

        public MainWindow()
        {
            InitializeComponent();

            IContainer countainer = Container.ConfigureContainer();

            brendRepository = countainer.Resolve<BrendRepository>();
            equipmentRepository = countainer.Resolve<EquipmentRepository>();
            toolTypeRepository = countainer.Resolve<ToolTypeRepository>();
            updateRepository = countainer.Resolve<UpdateRepository>();

            catalogRepository = new CatalogRepository(brendRepository, equipmentRepository, toolTypeRepository, updateRepository);
        }

        private void brends_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            var updatedBrend = e.Row.Item as Brend;
            brendRepository.AddOrUpdateFromDataGrid(updatedBrend);
        }

        private void equipments_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            var updatedEquipment = e.Row.Item as Equipment;
            equipmentRepository.AddOrUpdateFromDataGrid(updatedEquipment);
        }

        private void toolTypes_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            var updatedToolType = e.Row.Item as ToolType;
            toolTypeRepository.AddOrUpdateFromDataGrid(updatedToolType);
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            await catalogRepository.Synchronyze();

            brends.ItemsSource = brendRepository.GetLines();
            equipments.ItemsSource = equipmentRepository.GetLines();
            toolTypes.ItemsSource = toolTypeRepository.GetLines();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await catalogRepository.Synchronyze();

            brends.ItemsSource = brendRepository.GetLines();
            equipments.ItemsSource = equipmentRepository.GetLines();
            toolTypes.ItemsSource = toolTypeRepository.GetLines();
        }
    }
}
