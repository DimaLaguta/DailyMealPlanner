using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using CarRental.Utility;
using DailyMealPlanner.model.business;
using DailyMealPlanner.model.business.enums;
using DailyMealPlanner.model.service;
using DailyMealPlanner.src.model.service;
using DailyMealPlanner.view;
using GongSolutions.Wpf.DragDrop;
using Time = DailyMealPlanner.model.business.Time;

namespace DailyMealPlanner.viewModel
{
    public class MainViewModel : OnPropertyChangedClass, IDropTarget
    {
        private readonly ProductService productService = new ProductService();
        private readonly MealTimeService mealTimeService = new MealTimeService();
        private readonly UserService userService = new UserService();
        private readonly PdfService pdfService = new PdfService();

        public MainViewModel()
        {
            Weight = 81.0;
            Height = 186;
            Age = 19;

            mealTimeService.AddMealTime(Time.GetInstance("Завтрак"));
            mealTimeService.AddMealTime(Time.GetInstance("Обед"));
            mealTimeService.AddMealTime(Time.GetInstance("Ужин"));

            IsSelectedNormalActivity = true;
            CalculateAMR.Execute(null);

            ComboBoxCategories = productService.GetCategories();
            ComboBoxCategoriesIndex = 0;
            FilterProductByCategory.Execute(null);

            ComboBoxMealTimes = mealTimeService.GetNameOfMealTime();
            ComboBoxMealTimesIndex = 0;
            setProductForListBoxMealTime.Execute(null);

            CalculateCaloriesPerDay.Execute(null);
        }


        #region Data

        private double _weight;

        public double Weight
        {
            get => _weight;
            set
            {
                if (value >= 0)
                {
                    _weight = value;
                }
                else
                {
                    _weight = 1;
                }

                Bmr = userService.Bmr(Weight, Height, Age);
                OnPropertyChanged("Weight");
            }
        }

        private double _height;

        public double Height
        {
            get => _height;
            set
            {
                if (value >= 0)
                {
                    _height = value;
                }
                else
                {
                    _height = 1;
                }

                Bmr = userService.Bmr(Weight, Height, Age);
                OnPropertyChanged("Height");
            }
        }

        private int _age;

        public int Age
        {
            get => _age;
            set
            {
                if (value >= 0)
                {
                    _age = value;
                }
                else
                {
                    _age = 1;
                }

                Bmr = userService.Bmr(Weight, Height, Age);
                OnPropertyChanged("Age");
            }
        }

        private double _bmr;

        public double Bmr
        {
            get => _bmr;
            set
            {
                _bmr = value;
                UserCalories = userService.DailyCaloriesRate(Bmr, Amr);
                OnPropertyChanged("Bmr");
            }
        }

        #endregion

        #region Activity

        private bool _isSelectedLowActivity;

        public bool IsSelectedLowActivity
        {
            get => _isSelectedLowActivity;
            set
            {
                _isSelectedLowActivity = value;
                OnPropertyChanged("IsSelectedLowActivity");
            }
        }

        private bool _isSelectedNormalActivity;

        public bool IsSelectedNormalActivity
        {
            get => _isSelectedNormalActivity;
            set
            {
                _isSelectedNormalActivity = value;
                OnPropertyChanged("IsSelectedNormalActivity");
            }
        }

        private bool _isSelectedAverageActivity;

        public bool IsSelectedAverageActivity
        {
            get => _isSelectedAverageActivity;
            set
            {
                _isSelectedAverageActivity = value;
                OnPropertyChanged("IsSelectedAverageActivity");
            }
        }

        private bool _isSelectedHighActivity;

        public bool IsSelectedHighActivity
        {
            get => _isSelectedHighActivity;
            set
            {
                _isSelectedHighActivity = value;
                OnPropertyChanged("IsSelectedHighActivity");
            }
        }

        private ICommand _calculateAmr;

        public ICommand CalculateAMR => _calculateAmr ?? (_calculateAmr = new RelayCommand(obj =>
        {
            if (IsSelectedLowActivity)
            {
                Amr = userService.Amr(DailyActivity.LOW);
            }
            else if (IsSelectedNormalActivity)
            {
                Amr = userService.Amr(DailyActivity.NORMAL);
            }
            else if (IsSelectedAverageActivity)
            {
                Amr = userService.Amr(DailyActivity.AVERAGE);
            }
            else
            {
                Amr = userService.Amr(DailyActivity.HIGH);
            }
        }));

        private double _amr;

        public double Amr
        {
            get => _amr;
            set
            {
                _amr = value;
                UserCalories = userService.DailyCaloriesRate(Bmr, Amr);
                OnPropertyChanged("Amr");
            }
        }

        #endregion

        #region Reference Intakes

        private int _userCalories;

        public int UserCalories
        {
            get => _userCalories;
            set
            {
                _userCalories = value;
                OnPropertyChanged("UserCalories");
            }
        }

        private double _userProteins;

        public double UserProteins
        {
            get => _userProteins;
            set
            {
                _userProteins = value;
                OnPropertyChanged("UserProteins");
            }
        }

        private double _userFats;

        public double UserFats
        {
            get => _userFats;
            set
            {
                _userFats = value;
                OnPropertyChanged("UserFats");
            }
        }

        private double _userCarbs;

        public double UserCarbs
        {
            get => _userCarbs;
            set
            {
                _userCarbs = value;
                OnPropertyChanged("UserCarbs");
            }
        }

        #endregion

        #region List Products

        #region ComboBox

        private ObservableCollection<Category> _comboBoxCategories;

        public ObservableCollection<Category> ComboBoxCategories
        {
            get => _comboBoxCategories;
            set
            {
                _comboBoxCategories = value;
                OnPropertyChanged("ComboBoxCategories");
            }
        }

        private int _comboBoxCategoriesIndex;

        public int ComboBoxCategoriesIndex
        {
            get => _comboBoxCategoriesIndex;
            set
            {
                _comboBoxCategoriesIndex = value;
                OnPropertyChanged("ComboBoxCategoriesIndex");
            }
        }

        #endregion


        #region ListBox

        private ICommand _filterProductByCategory;

        public ICommand FilterProductByCategory => _filterProductByCategory ?? (_filterProductByCategory =
            new RelayCommand(obj =>
            {
                ListBoxOfProductsByCategory =
                    productService.GetProductByCategory(
                        ComboBoxCategories[ComboBoxCategoriesIndex]);
            }));

        private ObservableCollection<Product> _listBoxOfProductsByCategory;

        public ObservableCollection<Product> ListBoxOfProductsByCategory
        {
            get => _listBoxOfProductsByCategory;
            set
            {
                _listBoxOfProductsByCategory = value;
                OnPropertyChanged("ListBoxOfProductsByCategory");
            }
        }

        #endregion

        #endregion

        public void DragOver(IDropInfo dropInfo)
        {
            dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
            dropInfo.Effects = DragDropEffects.Copy;
        }

        public void Drop(IDropInfo dropInfo)
        {
            if (dropInfo.Data is Product drugProduct)
            {
                mealTimeService.AddProductByTime(drugProduct, ComboBoxMealTimeItem);
                setProductForListBoxMealTime.Execute(null);
                ProgressBarValue = mealTimeService.CalculateCaloriesPerDay();
                SelectedItemInListBoxMealTime = drugProduct;
            }
        }

        #region List Meal Time

        #region ComboBox

        private ObservableCollection<string> _comboBoxMealTimes;

        public ObservableCollection<string> ComboBoxMealTimes
        {
            get => _comboBoxMealTimes;
            set
            {
                _comboBoxMealTimes = value;
                OnPropertyChanged("ComboBoxMealTimes");
            }
        }

        private string _comboBoxMealTimeItem;

        public string ComboBoxMealTimeItem
        {
            get => _comboBoxMealTimeItem;
            set
            {
                _comboBoxMealTimeItem = value;
                OnPropertyChanged("ComboBoxMealTimeItem");
            }
        }


        private int _comboBoxMealTimesIndex;

        public int ComboBoxMealTimesIndex
        {
            get => _comboBoxMealTimesIndex;
            set
            {
                _comboBoxMealTimesIndex = value;
                OnPropertyChanged("ComboBoxMealTimesIndex");
            }
        }

        private ICommand _DeleteItemInComboBox;

        public ICommand DeleteItemInComboBox =>
            _DeleteItemInComboBox ?? (_DeleteItemInComboBox =
                new RelayCommand(obj =>
                {
                    if (ComboBoxMealTimeItem != null)
                    {
                        mealTimeService.DeleteMealTime(Time.GetInstance(ComboBoxMealTimes[ComboBoxMealTimesIndex]));
                    }
                    ComboBoxMealTimes = mealTimeService.GetNameOfMealTime();
                    ComboBoxMealTimesIndex = 0;
                    setProductForListBoxMealTime.Execute(null);
                    CalculateCaloriesPerDay.Execute(null);
                }));

        private ICommand _AddNewMealTime;

        public ICommand AddNewMealTime =>
            _AddNewMealTime ?? (_AddNewMealTime =
                new RelayCommand(obj =>
                {
                    EnterNewMealTime enterNewMealTime = new EnterNewMealTime();
                    enterNewMealTime.Show();
                }));

       
        #endregion

        #region ListBox

        private ICommand _setProductForListBoxMealTime;

        public ICommand setProductForListBoxMealTime =>
            _setProductForListBoxMealTime ?? (_setProductForListBoxMealTime =
                new RelayCommand(obj =>
                {
                    ProductsFromListBoxMealTime =
                        new ObservableCollection<Product>(
                            mealTimeService.GetProducts(
                                Time.GetInstance(
                                    ComboBoxMealTimes[ComboBoxMealTimesIndex])));
                }));

        private ObservableCollection<Product> _productsFromListBoxMealTime;

        public ObservableCollection<Product> ProductsFromListBoxMealTime
        {
            get => _productsFromListBoxMealTime;
            set
            {
                _productsFromListBoxMealTime = value;
                OnPropertyChanged("ProductsFromListBoxMealTime");
            }
        }

        private Product _SelectedItemInListBoxMealTime;

        public Product SelectedItemInListBoxMealTime
        {
            get => _SelectedItemInListBoxMealTime;
            set
            {
                _SelectedItemInListBoxMealTime = value;
                OnPropertyChanged("SelectedItemInListBoxMealTime");
            }
        }

        private ICommand _ChangedSelectedItemInListBoxMealTime;

        public ICommand ChangedSelectedItemInListBoxMealTime =>
            _ChangedSelectedItemInListBoxMealTime ?? (_ChangedSelectedItemInListBoxMealTime =
                new RelayCommand(obj =>
                {
                    if (SelectedItemInListBoxMealTime != null)
                    {
                        ProductWeight = (int) Math.Round(SelectedItemInListBoxMealTime.Gramms);
                    }
                }));

        private ICommand _ChangeGramms;

        public ICommand ChangeGramms =>
            _ChangeGramms ?? (_ChangeGramms =
                new RelayCommand(obj =>
                {
                    if (SelectedItemInListBoxMealTime != null)
                    {
                        SelectedItemInListBoxMealTime.Gramms = ProductWeight;
                    }

                    CalculateCaloriesPerDay.Execute(null);
                }));


        private ICommand _DeleteItem;

        public ICommand DeleteItem =>
            _DeleteItem ?? (_DeleteItem =
                new RelayCommand(obj =>
                {
                    if (SelectedItemInListBoxMealTime != null)
                    {
                        mealTimeService.DeleteProduct(Time.GetInstance(ComboBoxMealTimes[ComboBoxMealTimesIndex]),
                            SelectedItemInListBoxMealTime);
                    }

                    setProductForListBoxMealTime.Execute(null);

                    CalculateCaloriesPerDay.Execute(null);
                }));

        #endregion

        #endregion

        #region Product Information

        private int _ProductProteins;

        public int ProductProteins
        {
            get => _ProductProteins;
            set
            {
                _ProductProteins = value;
                OnPropertyChanged("ProductProteins");
            }
        }

        private int _ProductFats;

        public int ProductFats
        {
            get => _ProductFats;
            set
            {
                _ProductFats = value;
                OnPropertyChanged("ProductFats");
            }
        }

        private int _ProductCarbs;

        public int ProductCarbs
        {
            get => _ProductCarbs;
            set
            {
                _ProductCarbs = value;
                OnPropertyChanged("ProductCarbs");
            }
        }

        private int _ProductCalories;

        public int ProductCalories
        {
            get => _ProductCalories;
            set
            {
                _ProductCalories = value;
                OnPropertyChanged("ProductCalories");
            }
        }

        private int _ProductWeight;

        public int ProductWeight
        {
            get => _ProductWeight;
            set
            {
                _ProductWeight = value;
                OnPropertyChanged("ProductWeight");
            }
        }

        private ICommand _ChangeProductInformation;

        public ICommand ChangeProductInformation =>
            _ChangeProductInformation ?? (_ChangeProductInformation =
                new RelayCommand(obj =>
                {
                    if (SelectedItemInListBoxMealTime != null)
                    {
                        ProductProteins = (int) Math.Round(ProductWeight / SelectedItemInListBoxMealTime.GrammsBase *
                                                           SelectedItemInListBoxMealTime.Protein);
                        ProductFats = (int) Math.Round(ProductWeight / SelectedItemInListBoxMealTime.GrammsBase *
                                                       SelectedItemInListBoxMealTime.Fats);
                        ProductCarbs = (int) Math.Round(ProductWeight / SelectedItemInListBoxMealTime.GrammsBase *
                                                        SelectedItemInListBoxMealTime.Carbs);
                        ProductCalories = (int) Math.Round(ProductWeight / SelectedItemInListBoxMealTime.GrammsBase *
                                                           SelectedItemInListBoxMealTime.Calories);
                    }
                }));

        #endregion

        #region Progress Bar

        private Brush _ProgressBarTextBlockColor;

        public Brush ProgressBarTextBlockColor
        {
            get => _ProgressBarTextBlockColor;
            set
            {
                _ProgressBarTextBlockColor = value;
                OnPropertyChanged("ProgressBarTextBlockColor");
            }
        }

        private string _ProgressBarTextBlockText;

        public string ProgressBarTextBlockText
        {
            get => _ProgressBarTextBlockText;
            set
            {
                _ProgressBarTextBlockText = value;
                OnPropertyChanged("ProgressBarTextBlockText");
            }
        }


        private int _ProgressBarValue;

        public int ProgressBarValue
        {
            get => _ProgressBarValue;
            set
            {
                _ProgressBarValue = value;
                if (ProgressBarValue > UserCalories)
                {
                    ProgressBarTextBlockText = $"Превышена норма Ккалорий на {ProgressBarValue - UserCalories}";
                    ProgressBarTextBlockColor = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    ProgressBarTextBlockColor = new SolidColorBrush(Colors.Black);
                    ProgressBarTextBlockText = "Ккалорий: " + value;
                }

                OnPropertyChanged("ProgressBarValue");
            }
        }

        private ICommand _CalculateCaloriesPerDay;

        public ICommand CalculateCaloriesPerDay =>
            _CalculateCaloriesPerDay ?? (_CalculateCaloriesPerDay =
                new RelayCommand(obj => { ProgressBarValue = mealTimeService.CalculateCaloriesPerDay(); }));

        #endregion

        #region Buttons

        private ICommand _DeleteAllProductsFromCurrentMealTime;

        public ICommand DeleteAllProductsFromCurrentMealTime =>
            _DeleteAllProductsFromCurrentMealTime ?? (_DeleteAllProductsFromCurrentMealTime =
                new RelayCommand(obj =>
                {
                    mealTimeService.DeleteAllProducts(ComboBoxMealTimes[ComboBoxMealTimesIndex]);
                    setProductForListBoxMealTime.Execute(null);
                    ProgressBarValue = mealTimeService.CalculateCaloriesPerDay();
                }));

        private ICommand _SavePdf;

        public ICommand SavePdf =>
            _SavePdf ?? (_SavePdf =
                new RelayCommand(obj =>
                {
                    pdfService.CreateSavePdf(new UserInformation(Weight, Age, Height, Bmr, Amr),
                        mealTimeService.GetMealTimes());
                }));

        #endregion
    }
}