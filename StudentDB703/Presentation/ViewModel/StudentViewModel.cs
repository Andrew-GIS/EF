using System;
using System.Collections.ObjectModel;
using DAL.Model;
using DAL.Services;
using Presentation.Extensions;


namespace Presentation.ViewModel
{
    public class StudentViewModel : ViewModelBase.ViewModelBase
    {
        private ObservableCollection<Student> students;
        private Student selectedStudent;
        private readonly IStudentService studentService;
        private ObservableCollection<Book> books;
        private Book selectedBook;
        private int booksCount;
        private ObservableCollection<Address> addresses;
        private Address selectedAddress;
        

        public StudentViewModel(IStudentService studentService)
        {
            if (studentService == null) throw new ArgumentNullException(nameof(studentService));

            this.studentService = studentService;
            Students = new ObservableCollection<Student>();

            GetStudentsCommmand = new DelegateCommand.DelegateCommand(ExecuteGetStudents);
            SaveStudentsCommand = new DelegateCommand.DelegateCommand(ExecuteSaveStudents, CanExecuteSaveDeleteStudents);
            DeleteStudentsCommand = new DelegateCommand.DelegateCommand(ExecuteDeleteStudent, CanExecuteSaveDeleteStudents);
        }

        private bool CanExecuteSaveDeleteStudents()
        {
            return this.selectedStudent != null;
        }

        private void ExecuteSaveStudents()
        {
            this.studentService.SaveStudents();
        }

        private void ExecuteGetStudents()
        {
            this.Students = this.studentService.GetStudents().ToObservableCollection();
            
        }

        private void ExecuteDeleteStudent()
        {
            this.studentService.DeleteStudent(selectedStudent);
            ExecuteSaveStudents();
            ExecuteGetStudents();

        }

        public ObservableCollection<Student> Students
        {
            get { return this.students; }
            set
            {
                this.students = value;
                OnPropertyChanged();
            }
        }

        public Student SelectedStudent
        {
            get { return this.selectedStudent; }
            set
            {
                this.selectedStudent = value;
                this.BooksCount = SelectedStudent.Books.Count;
                //SelectedAddress = selectedAddress;
                OnPropertyChanged();
            }
        }


        public Book SelectedBook
        {
            get { return this.selectedBook; }
            set
            {
                this.selectedBook = value;
                OnPropertyChanged();
            }
        }

        public int  BooksCount
        {
            get { return this.booksCount; }
            set
            {
                this.booksCount = value;
                OnPropertyChanged();
            }
        }

        public Address SelectedAddress
        {
            get { return this.selectedAddress; }
            set
            {
                this.selectedAddress = value;
                OnPropertyChanged();
            }
        }

        public DelegateCommand.DelegateCommand GetStudentsCommmand { get; }

        public DelegateCommand.DelegateCommand SaveStudentsCommand { get; }

        public DelegateCommand.DelegateCommand DeleteStudentsCommand { get; }

    }
}