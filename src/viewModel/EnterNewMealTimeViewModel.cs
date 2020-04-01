using System.Windows;
using System.Windows.Input;
using CarRental.Utility;
using DailyMealPlanner.model.business;
using DailyMealPlanner.model.service;
using DailyMealPlanner.src.view;

namespace DailyMealPlanner.viewModel
{
    public class EnterNewMealTimeViewModel : OnPropertyChangedClass
    {
        private readonly MealTimeService mealTimeService = new MealTimeService();

        private string _NewMealTimeName;

        public string NewMealTimeName
        {
            get => _NewMealTimeName;
            set
            {
                _NewMealTimeName = value;
                OnPropertyChanged("NewMealTimeName");
            }
        }

        private ICommand _SubmitMealTime;

        public ICommand SubmitMealTime =>
            _SubmitMealTime ?? (_SubmitMealTime =
                new RelayCommand(obj =>
                {
                    mealTimeService.AddMealTime(Time.GetInstance(NewMealTimeName));


                    Window main = null;
                    foreach (Window i in Application.Current.Windows)
                    {
                        if (i is Main)
                        {
                            main = i as Main;
                        }
                    }

                    MainViewModel mainViewModel = main?.DataContext as MainViewModel;
                    mainViewModel.ComboBoxMealTimes = mealTimeService.GetNameOfMealTime();

                    Window window = obj as Window;
                    window?.Close();
                }));
    }
}