using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Desktop01.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Prism.Mvvm;
using Prism.Commands;

namespace Desktop01
{
    public  partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public  ObservableCollection<User> users;

        [ObservableProperty]
        public User selectedStudent;






        //private DelegateCommand<User> delete_command;
        // public DelegateCommand<User> DeleteCommand =>
        //     delete_command ?? (delete_command = new DelegateCommand<User>(executeDeleteCommand));
        // void executeDeleteCommand(User parameter)
        // {
        //     var hm = MessageBox.Show($"Are you sure want to delete {parameter.FirstName}", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
        //     if(hm == MessageBoxResult.Yes)
        //     {
        //         Users.Remove(parameter);
        //     }
        // }



        // private DelegateCommand<User> _editCommand;
        // public DelegateCommand<User> EditCommand =>
        //     _editCommand ?? (_editCommand = new DelegateCommand<User>(ExecuteEditCommand));

        // void ExecuteEditCommand(User parameter)
        // {


        //     var vm = new AddUserVM(parameter);
        //     vm.title = "EDIT USER";
        //     var window = new AddUserWindow(vm);

        //     window.ShowDialog();


        //     int index = users.IndexOf(parameter);
        //     users.RemoveAt(index);
        //     users.Insert(index, vm.Student);
        // }



        [RelayCommand]
        public void Delete()
        {
            if(selectedStudent != null)
            {
                int index = Users.IndexOf(selectedStudent);
                Users.RemoveAt(index);

            }
            else
            {
                MessageBox.Show("Please Select Student before Delete.", "Error");


            }

        }


        [RelayCommand]
        public void Edit()
        {
            if (selectedStudent != null)
            {

                var addUserVM = new AddUserVM(selectedStudent);
                addUserVM.title = "EDIT USER";
                var window = new AddUserWindow(addUserVM);

                window.ShowDialog();


                int index = users.IndexOf(selectedStudent);
                users.RemoveAt(index);
                users.Insert(index, addUserVM.Student);

            }
            else
            {
                MessageBox.Show("Plese Select Student before edit.", "Error");


            }

        }




        [RelayCommand]
        public void AddStudent()
        {
            var vm = new AddUserVM();
            vm.title = "ADD USER";
            AddUserWindow window = new AddUserWindow(vm);
            window.ShowDialog();

            if (vm.Student != null)
            {
                users.Add(vm.Student);
            }
        }

    
    

        public  MainWindowVM()
        {
            users = new ObservableCollection<User>();
            BitmapImage image1 = new BitmapImage(new Uri("/Model/Images/1.png", UriKind.Relative));
            users.Add(new User(23, "Jos", "Buttler", "11/1/2000",image1));
            BitmapImage image2 = new BitmapImage(new Uri("/Model/Images/2.png", UriKind.Relative));
            users.Add(new User(23, "Lionel", "Messi", "12/10/2000",image2));
            BitmapImage image3 = new BitmapImage(new Uri("/Model/Images/3.png", UriKind.Relative));
            users.Add(new User(24, "Kumar", "Sangakkara", "24/12/1999",image3));
            BitmapImage image4= new BitmapImage(new Uri("/Model/Images/4.png", UriKind.Relative));
            users.Add(new User(24, "Iga", "Swiatek", "03/07/1999", image4));
            users.Add(new User(23, "Rafael", "Nadal", "30/06/2000", image2));
            users.Add(new User(23, "Carolina", "Merin", "21/04/2000", image4)); 
            users.Add(new User(24, "Babar", "Azam", "01/05/1999", image1));
            users.Add(new User(23, "Shane", "Watson", "27/09/2000", image3));


        }
    }
}
