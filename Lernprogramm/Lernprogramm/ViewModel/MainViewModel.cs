using Lernprogramm.Addition;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lernprogramm.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            HideAllGrids();
            StartGridVisibility = Visibility.Visible;
        }

        /// <summary>
        /// Button Startseite
        /// </summary>
        public DelegateCommand StartBtn
        {
            get { return new DelegateCommand((o) => CanExecuteStartBtn(), (o) => ExecuteStartBtn()); }                
        }

        private bool CanExecuteStartBtn()
        {
            return true;
        }
        private void ExecuteStartBtn()
        {
            HideAllGrids();
            MenuGridVisibility = Visibility.Visible;
        }

        /// <summary>
        /// Operatorauswahl Addition Button
        /// </summary>
        public DelegateCommand OperatorAdditionBtn
        {
            get 
            { 
                return new DelegateCommand(
                    (o) => CanExecuteOperatorAdditionBtn(), 
                    (o) => ExecuteOperatorAdditionBtn()); 
            }
        }
        private bool CanExecuteOperatorAdditionBtn()
        {
            return true;
        }
        private void ExecuteOperatorAdditionBtn()
        {
            HideAllGrids();
            Caption = "PLUS RECHNEN";
            DifficultyGridVisibility = Visibility.Visible;
            OperatorText = AdditionLogic.OperatorText;
        }

        /// <summary>
        /// Schwierigkeitsauswahl Einfach Button
        /// </summary>
        public DelegateCommand EasyDifficultyBtn
        {
            get
            {
                return new DelegateCommand(
                    (o) => CanExecuteEasyDifficulty(),
                    (o) => ExecuteEasyDifficulty());
            }
        }
        private bool CanExecuteEasyDifficulty()
        {
            return true;
        }
        private void ExecuteEasyDifficulty()
        {
            HideAllGrids();
            QuantityGridVisibility = Visibility.Visible;
            AdditionLogic.DifficultyLvl = 1;
        }

        /// <summary>
        /// Schwierigkeitsauswahl Mittel Button
        /// </summary>
        public DelegateCommand MediumDifficultyBtn
        {
            get
            {
                return new DelegateCommand(
                    (o) => CanExecuteMediumDifficulty(),
                    (o) => ExecuteMediumDifficulty());
            }
        }
        private bool CanExecuteMediumDifficulty()
        {
            return true;
        }
        private void ExecuteMediumDifficulty()
        {
            HideAllGrids();
            QuantityGridVisibility = Visibility.Visible;
            AdditionLogic.DifficultyLvl = 2;
        }

        /// <summary>
        /// Schwierigkeitsauswahl Schwer Button
        /// </summary>
        public DelegateCommand HardDifficultyBtn
        {
            get
            {
                return new DelegateCommand(
                    (o) => CanExecuteHardDifficulty(),
                    (o) => ExecuteHardDifficulty());
            }
        }
        private bool CanExecuteHardDifficulty()
        {
            return true;
        }
        private void ExecuteHardDifficulty()
        {
            HideAllGrids();
            QuantityGridVisibility = Visibility.Visible;
            AdditionLogic.DifficultyLvl = 3;
        }

        /// <summary>
        /// Auswahl der Aufgabenmenge Button
        /// </summary>
        public DelegateCommand ChooseQuantityBtn
        {
            get
            {
                return new DelegateCommand(
                    (o) => CanExecuteChooseQuantity(),
                    (o) => ExecuteChooseQuantity(int.Parse(o.ToString())));
            }
        }
        private bool CanExecuteChooseQuantity()
        {
            return true;
        }
        private void ExecuteChooseQuantity(int quantity)
        {
            HideAllGrids();
            AdditionLogic.Quantity = quantity;
            GetRandomNumbers();
            CalculationGridVisibility = Visibility.Visible;        
        }

        /// <summary>
        /// Übertrag 1 Button
        /// </summary>
        public DelegateCommand Transfer1Btn
        {
            get
            {
                return new DelegateCommand(
                    (o) => CanExecuteTransfer1(),
                    (o) => ExecuteTransfer1());
            }
        }
        private bool CanExecuteTransfer1()
        {
            return true;
        }
        private void ExecuteTransfer1()
        {
            TransferBtnContent1 = string.IsNullOrEmpty(TransferBtnContent1) ? "1" : "";
        }

        /// <summary>
        /// Übertrag 2 Button
        /// </summary>
        public DelegateCommand Transfer2Btn
        {
            get
            {
                return new DelegateCommand(
                    (o) => CanExecuteTransfer2(),
                    (o) => ExecuteTransfer2());
            }
        }
        private bool CanExecuteTransfer2()
        {
            return true;
        }
        private void ExecuteTransfer2()
        {
            TransferBtnContent2 = string.IsNullOrEmpty(TransferBtnContent2) ? "1" : "";
        }

        private void GetRandomNumbers()
        {
            AdditionLogic.GenerateAdditionNumbers();
            FirstNumberText = AdditionLogic.Number1.ToString();
            SecondNumberText = AdditionLogic.Number2.ToString();
        }

        // Allgemein
        private string caption;
        public string Caption
        {
            get { return caption; }
            set 
            {
                if (caption != value)
                {
                    caption = value;
                    RaisePropertyChanged();
                }           
            }
        }

        /// <summary>
        /// Button Eingabe bestätigen
        /// </summary>
        public DelegateCommand CalculateBtn
        {
            get { return new DelegateCommand((o) => CanExecuteCalculate(), (o) => ExecuteCalculate()); }
        }
        private bool CanExecuteCalculate()
        {
            return true;
        }
        private void ExecuteCalculate()
        {
            ResetTransfer();
            bool resultCheck = AdditionLogic.CheckAddition(int.Parse(InputText));

            if (resultCheck)
            {
                AdditionLogic.CorrectCount++;
                Response = "Richtig!";
                FeedbackGridVisibility = Visibility.Visible;
            }
            else
            {
                AdditionLogic.WrongCount++;
                Response = "Leider nicht richtig!";
                FeedbackGridVisibility = Visibility.Visible;
            }

            // Nächste Aufgabe laden
            if (AdditionLogic.LoadNextTask())
            {
                ResetTransfer();
                InputText = "";
                AdditionLogic.GenerateAdditionNumbers();
                FirstNumberText = AdditionLogic.Number1.ToString();
                SecondNumberText = AdditionLogic.Number2.ToString();
            }
            else
            {
                HideAllGrids();
                ResultText = "Du hast " + AdditionLogic.CorrectCount + " von " + AdditionLogic.Quantity + " Aufgaben richtig gelöst";
                ResultGridVisibility = Visibility.Visible;
            }
        }

        // PlusTraining
        private DelegateCommand startAdditionTrainingBtn;
        public DelegateCommand StartAdditionTrainingBtn 
        { 
            get
            {
                return startAdditionTrainingBtn;
            }
            set
            {
                startAdditionTrainingBtn = value;
            }
        }     

        // Menu
        public string Menu1 { get; set; }
        public string Menu2 { get; set; }
        public string Menu3 { get; set; }
        public string Menu4 { get; set; }
        public string Menu5 { get; set; }
        public string Menu6 { get; set; }

        // Bei der Rechnung
        private string operatorText;
        public string OperatorText
        {
            get { return operatorText; }
            set
            {
                if (operatorText != value)
                {
                    operatorText = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string firstNumberText;
        public string FirstNumberText
        {
            get { return firstNumberText; }
            set
            {
                if (firstNumberText != value)
                {
                    firstNumberText = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string secondNumberText;
        public string SecondNumberText
        {
            get { return secondNumberText; }
            set
            {
                if (secondNumberText != value)
                {
                    secondNumberText = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string inputText;
        public string InputText
        {
            get { return inputText; }
            set
            {
                if (inputText != value)
                {
                    inputText = value;
                    this.RaisePropertyChanged();
                    this.CalculateBtn.RaiseCanExecuteChanged();
                }
            }
        }

        /// <summary>
        /// Eigenschaft für den Übertrag1
        /// </summary>
        private string transferBtnContent1;
        public string TransferBtnContent1
        {
            get { return transferBtnContent1; }
            set
            {
                if (transferBtnContent1 != value)
                {
                    transferBtnContent1 = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Eigenschaft für den Übertrag2
        /// </summary>
        private string transferBtnContent2;
        public string TransferBtnContent2
        {
            get { return transferBtnContent2; }
            set
            {
                if (transferBtnContent2 != value)
                {
                    transferBtnContent2 = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Eigenschaft für den Übertrag2
        /// </summary>
        private string resultText;
        public string ResultText
        {
            get { return resultText; }
            set
            {
                if (resultText != value)
                {
                    resultText = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        // Visibility Eigenschaften       
        /// <summary>
        /// Eigenschaft für die Sichtbarkeit der Startseite
        /// </summary>
        private Visibility startGridVisibility;
        public Visibility StartGridVisibility
        {
            get { return startGridVisibility; }
            set
            {
                if (startGridVisibility != value)
                {
                    startGridVisibility = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Eigenschaft für Menu Sichtbarkeit
        /// </summary>
        private Visibility menuGridVisibility;
        public Visibility MenuGridVisibility
        {
            get { return menuGridVisibility; }
            set
            {
                if (menuGridVisibility != value)
                {
                    menuGridVisibility = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Eigenschaft für Schwierigkeitsauswahl-Sichtbarkeit
        /// </summary>
        private Visibility difficultyGridVisibility;
        public Visibility DifficultyGridVisibility
        {
            get { return difficultyGridVisibility; }
            set
            {
                if (difficultyGridVisibility != value)
                {
                    difficultyGridVisibility = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Eigenschaft für die Sichtarbkeit der Aufgabenmenge
        /// </summary>
        private Visibility quantityGridVisibility;
        public Visibility QuantityGridVisibility
        {
            get { return quantityGridVisibility; }
            set
            {
                if (quantityGridVisibility != value)
                {
                    quantityGridVisibility = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Eigenschaft für Sichtbarkeit der Rechnungsseite
        /// </summary>
        private Visibility calculationGridVisibility;
        public Visibility CalculationGridVisibility
        {
            get { return calculationGridVisibility; }
            set
            {
                if (calculationGridVisibility != value)
                {
                    calculationGridVisibility = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Eigenschaft für Sichtbarkeit der Feedbackseite
        /// </summary>
        private Visibility feedbackGridVisibility;
        public Visibility FeedbackGridVisibility
        {
            get { return feedbackGridVisibility; }
            set
            {
                if (feedbackGridVisibility != value)
                {
                    feedbackGridVisibility = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Eigenschaft für Sichtbarkeit der Leistungsübersicht
        /// </summary>
        private Visibility resultGridVisibility;
        public Visibility ResultGridVisibility
        {
            get { return resultGridVisibility; }
            set
            {
                if (resultGridVisibility != value)
                {
                    resultGridVisibility = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Eigenschaft für Sichtbarkeit des Minispiels
        /// </summary>
        private Visibility minGameGridVisibility;
        public Visibility MinGameGridVisibility
        {
            get { return minGameGridVisibility; }
            set
            {
                if (minGameGridVisibility != value)
                {
                    minGameGridVisibility = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Eigenschaft für Sichtbarkeit des Minispiels
        /// </summary>
        private Visibility numberOrderGridVisibility;
        public Visibility NumberOrderGridVisibility
        {
            get { return numberOrderGridVisibility; }
            set
            {
                if (numberOrderGridVisibility != value)
                {
                    numberOrderGridVisibility = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Eigenschaft für das Feedback
        /// </summary>
        private string response;
        public string Response
        {
            get { return response; }
            set
            {
                if (response != value)
                {
                    response = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Setzt die Werte in den Übertragsfeldern zurück.
        /// </summary>
        public void ResetTransfer()
        {
            TransferBtnContent1 = "";
            TransferBtnContent2 = "";
        }

        /// <summary>
        /// Blendet alle Grids aus.
        /// </summary>
        public void HideAllGrids()
        {
            StartGridVisibility = Visibility.Hidden;
            MenuGridVisibility = Visibility.Hidden;
            DifficultyGridVisibility = Visibility.Hidden;
            QuantityGridVisibility = Visibility.Hidden;
            CalculationGridVisibility = Visibility.Hidden;
            ResultGridVisibility = Visibility.Hidden;
            MinGameGridVisibility = Visibility.Hidden;
            NumberOrderGridVisibility = Visibility.Hidden;
            FeedbackGridVisibility = Visibility.Hidden;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string prop = "")
        {
            if (string.IsNullOrEmpty(prop))
                return;

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
