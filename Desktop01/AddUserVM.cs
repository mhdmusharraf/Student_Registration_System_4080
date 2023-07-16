using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Desktop01.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Desktop01
{
    public partial class AddUserVM : ObservableObject

    {
        
   
        [ObservableProperty]
        public string firstname;


        [ObservableProperty]
        public string lastname;

        [ObservableProperty]
        public int age;

        [ObservableProperty]
        public string dateofbirth;

        [ObservableProperty]
        public double gpa;

     

        //To change the tile



        [ObservableProperty]
        public string title;

        [ObservableProperty]
        public BitmapImage selectedImage;

      

        public AddUserVM(User u)
        {
            Student = u;
          
            firstname  = Student.FirstName;
            lastname = Student.LastName;
            age = Student.Age;
            gpa = Student.GPA;
            dateofbirth = Student.DateOfBirth;
            selectedImage=Student.Image;
            
        }
        public AddUserVM()
        {
            
        }


        //get image 
        [RelayCommand]
        public void UploadPhoto()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == true)
            {
                SelectedImage = new BitmapImage(new Uri(dialog.FileName));
               
                MessageBox.Show("Imgae successfuly uploded!", "successfull");
            }
        }






        public User Student { get; private set; }
        public Action CloseAction { get; internal set; }
        
        [RelayCommand]
        public void Save()
        {
          
            
            
            if (gpa<0 || gpa>4) {
                MessageBox.Show("GPA value must be between 0 and 4.", "Error" );
                return;
            }
            if(Student==null)
            {

                Student = new User()
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Age = age,
                    DateOfBirth = dateofbirth,
                    Image = selectedImage,

                    GPA = gpa

                };


            }
            else
            {
                
                Student.FirstName = firstname;
                Student.LastName = lastname;
                Student.Age = age;
                Student.GPA = gpa;
                Student.Image = selectedImage;
                Student.DateOfBirth = dateofbirth;
                
                
                
            }

            if (Student.FirstName == null) MessageBox.Show("First Name cannot be Empty ", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (Student.LastName == null) MessageBox.Show("Last Name cannot be Empty", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (Student.Age <= 0) MessageBox.Show("Invalid input for age", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (Student.DateOfBirth == null) MessageBox.Show("Please enter the Date of Birth", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (Student.GPA < 0 || Student.GPA > 4) MessageBox.Show("GPA should be in between 0 to 4", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (Student.Image == null) MessageBox.Show("Upload a Photo!!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                CloseAction();
            }

            Application.Current.MainWindow.Show();


        }
    }
}
