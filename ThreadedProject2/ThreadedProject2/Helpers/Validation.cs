using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

// Author: Gavin, Skye, Samuel

namespace ThreadedProject2
{
    internal class Validation
    {
        /// <summary>
        /// Checks if value is decimal. returns boolean
        /// </summary>
        /// <param name="value">Value to be evaluated</param>
        /// <param name="name">Name of field for exceptions</param>
        /// <returns></returns>
        static public bool IsDecimal(TextBox txt)
        {
            bool success = true;
            try
            {
                // checks if value is both a decimal and not empty
                if (txt.Text == "") throw new Exception($"{txt.Tag} cannot be left empty");

                if (!Decimal.TryParse(txt.Text, out decimal v))
                    throw new Exception($"{txt.Tag} is invalid. Can only contain 0-9 and '.'");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                success = false;
            }

            return success;
        }

        /// <summary>
        /// Checks if value is a single word. returns boolean
        /// </summary>
        /// <param name="word">Value to be evaluated</param>
        /// <param name="name">Name of field for exceptions</param>
        /// <returns></returns>
        static public bool IsWord(TextBox txt)
        {
            bool success = true;
            try
            {
                // Checks if value is blank and that it contains only letters
                Regex reg = new Regex("(^[a-zA-Z]+)$");
                if (txt.Text == "") throw new Exception($"{txt.Tag} cannot be left empty");
                if (!reg.IsMatch(txt.Text))
                    throw new Exception($"{txt.Tag} is Invalid. Can only contain letters");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                success = false;
            }

            return success;
        }

        /// <summary>
        /// Checks if value is a sentence without numbers. returns boolean
        /// </summary>
        /// <param name="str">Value to be evaluated</param>
        /// <param name="name">Name of field for exceptions</param>
        /// <returns></returns>
        static public bool IsSentence(TextBox txt)
        {
            bool success = true;
            try
            {
                // validates that sentence does not contain multiple spaces between words and has no numbers
                Regex reg = new Regex("^([a-zA-Z]+([-.]?[a-zA-Z]+)*[\\s&-]?)*[a-zA-Z]+([-.][a-zA-Z]+)*$");
                if (txt.Text == "") throw new Exception($"{txt.Tag} cannot be empty");
                if (!reg.IsMatch(txt.Text.TrimEnd()))
                    throw new Exception($"{txt.Tag} is invalid. Can only contain letters and spaces!");
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Ensure that sentence does not have multiple spaces or numbers.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                success = false;
            }

            return success;
        }

        /// <summary>
        /// Check's date to ensure it is not in the past
        /// </summary>
        /// <param name="dtp">DateTimePicker to compare the date to</param>
        /// <param name="name">name ie "Date" for error messages</param>
        /// <returns></returns>
        static public bool CheckDate(DateTimePicker dtp)
        {
            bool success = true;
            try
            {
                if (dtp.Value < DateTime.Now) throw new Exception($"{dtp.Tag} cannot be in the past");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                success = false;
            }

            return success;
        }

        /// <summary>
        /// shows a message box and focuses on the invalid text box
        /// </summary>
        /// <param name="textBox"> text box to check (Tag property specifies meaning)</param>
        /// <param name="message"> the message to show in the message box</param>
        public static void ShowInvalidInput(TextBox textBox, string message)
        {
            MessageBox.Show(textBox.Tag + " " + message);
            textBox.SelectAll();
            textBox.Focus();
        }

        /// <summary>
        /// checks if the text box contains a string other than ""
        /// </summary>
        /// <param name="textBox"> text box to check (Tag property specifies meaning)</param>
        public static bool IsPresent(TextBox textBox)
        {
            if (textBox.Text == "")
            {
                ShowInvalidInput(textBox, "needs to be filled.");
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// checks if text box contains non-negative decimal
        /// </summary>
        /// <param name="textBox"> text box to check (Tag property specifies meaning)</param>
        /// <returns>true if valid and false if not</returns>
        public static bool IsNonNegativeDecimal(TextBox textBox)
        {
            if (IsPresent(textBox))
            {
                Decimal value;
                if (Decimal.TryParse(textBox.Text, out value))
                {
                    if (value < 0)
                    {
                        ShowInvalidInput(textBox, "must not be negative.");
                        return false;
                    }

                    return true;
                }
                else
                {
                    ShowInvalidInput(textBox, "must be a decimal number.");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// checks if text box contains non-negative integer
        /// </summary>
        /// <param name="textBox"> text box to check (Tag property specifies meaning)</param>
        /// <returns>true if valid and false if not</returns>
        public static bool IsNonNegativeInteger(TextBox textBox)
        {
            bool isValid = true;
            if (!int.TryParse(textBox.Text, out int value)) // bad int
            {
                isValid = false;
                MessageBox.Show($@"{textBox.Tag} has to be a whole number");
                textBox.SelectAll();
                textBox.Focus();
            }
            else if (value < 0) // negative
            {
                isValid = false;
                MessageBox.Show($@"{textBox.Tag} must be positive or zero");
                textBox.SelectAll();
                textBox.Focus();
            }

            return isValid;
        }

        /// <summary>
        /// checks if text box contains a valid DateTime
        /// </summary>
        /// <param name="textBox"> text box to check (Tag property specifies meaning)</param>
        /// <returns>true if valid and false if not</returns>
        public static bool IsDateTime(TextBox textBox)
        {
            if (IsPresent(textBox))
            {
                bool result = DateTime.TryParse(textBox.Text, out DateTime dtResult);
                if (!result)
                {
                    ShowInvalidInput(textBox, "must be a valid date.");
                }

                return result;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if a textbox text length does not exceed the specified maximum length.
        /// </summary>
        /// <param name="textBox">Text box to check</param>
        /// <param name="maxLength">Maximum allowed length</param>
        /// <returns>true if valid and false if not</returns>
        public static bool CheckLength(TextBox textBox, int maxLength)
        {
            bool isValid = true;
            if (textBox.Text.Length > maxLength)
            {
                isValid = false;
                MessageBox.Show($"{textBox.Tag} cannot exceed {maxLength} characters.");
                textBox.SelectAll();
                textBox.Focus();
            }

            return isValid;
        }

        /// <summary>
        /// Regex Check for Proper Address
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool IsAddress(TextBox txt)
        {
            bool isValid = true;
            try
            {
                Regex reg = new Regex("^\\d+(?:\\s\\d+)?\\s[A-Za-z]+(?:\\s[A-Za-z]+)*$");
                if (txt.Text == "") throw new Exception($"Address cannot be left empty");
                if (!reg.IsMatch(txt.Text)) throw new Exception("Address is invalid must be in format of 123 main st");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                isValid = false;
            }

            return isValid;
        }
        
        /// <summary>
        /// Regex for a Correct ZZ Province Code 
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool IsProvince(TextBox txt)
        {
            bool isValid = true;
            try
            {
                Regex reg = new Regex("^[a-zA-Z][a-zA-Z]$");
                if (txt.Text == "") throw new Exception($"Province/State cannot be left empty");
                if (!reg.IsMatch(txt.Text)) throw new Exception($@"Province/state is invalid. Can only be two letters ie 'AB'");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Regex Check for correct Postal Code Format ZZZ-ZZZ
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool IsPostalCode(TextBox txt)
        {
            bool isValid = true;
            try
            {
                Regex reg = new Regex("^\\w\\d\\w\\ ?\\d\\w\\d$");
                Regex reg2 = new Regex("^\\d{5}$");
                if (txt.Text == "") throw new Exception($"Postal code/Zip code cannot be left empty");
                if (!reg.IsMatch(txt.Text) && !reg2.IsMatch(txt.Text)) throw new Exception($@"Postal code/ zip code is invalid. Must be in format A1A 1A1/A1A1A1 or 12345");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Regex check for a valid Phone Number 000-000-0000
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool IsPhoneNumber(TextBox txt)
        {
            bool isValid = true;
            try
            {
                Regex reg = new Regex("^\\(?\\d{3}\\)?[\\s-]?\\d{3}[\\s-]?\\d{4}$");
                if (txt.Text == "") throw new Exception($"{txt.Tag} cannot be left empty");
                if (!reg.IsMatch(txt.Text)) throw new Exception($"{txt.Tag} is invalid. Must be in format 123-123-1234 or \n 123 123 1234 or (123) 123-1234");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Regex check for Valid Email example@email.com
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool IsEmail(TextBox txt)
        {
            bool isValid = true;
            try
            {
                Regex reg = new Regex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$");
                if (txt.Text == "") throw new Exception($"Email cannot be left empty");
                if (!reg.IsMatch(txt.Text)) throw new Exception($"Email is invalid. Please enter a valid email in the format john.doe@example.com");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Regex Check for a valid URL https://example.com
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool IsURL(TextBox txt)
        {
            bool isValid = true;
            try
            {
                Regex reg = new Regex("^(https?:\\/\\/)?(www\\.)?[a-zA-Z0-9\\-]+(\\.com|\\.ca|\\.net|\\.org|\\.co|\\.gov|\\.edu|\\.ca)$");
                if (txt.Text == "") throw new Exception($"URL cannot be left empty");
                if (!reg.IsMatch(txt.Text)) throw new Exception($"URL is invalid. mywebsite.com. You can also include https:// and 'www.'. Endings can include .com/.net/.co etc.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Validate if there is an Item selected
        /// </summary>
        /// <param name="cbo"></param>
        /// <returns></returns>
        public static bool ItemSelected(ComboBox cbo)
        {
            bool isValid = true;
            try
            {
                if (cbo.SelectedItem == null) throw new Exception($"{cbo.Tag} must have a selected item");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                isValid = false;
            }

            return isValid;
        }
    }
}