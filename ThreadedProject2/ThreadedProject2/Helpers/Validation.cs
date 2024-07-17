/*
 * AUTHOR: GAVIN OIAMO
 * DATE: 2024/07/03
 * PURPOSE: CLASS FOR VALIDATION
 */

using System.Text.RegularExpressions;

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
        static public bool IsDecimal(string value, string name)
        {
            bool success = true;
            try
            {
                // checks if value is both a decimal and not empty
                if (value == "") throw new Exception($"{name} cannot be left empty");

                if (!Decimal.TryParse(value, out decimal v))
                    throw new Exception($"{name} is invalid. Can only contain 0-9 and '.'");
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
        static public bool IsWord(string word, string name)
        {
            bool success = true;
            try
            {
                // Checks if value is blank and that it contains only letters
                Regex reg = new Regex("(^[a-zA-Z]+)$");
                if (word == "") throw new Exception($"{name} code cannot be left empty");
                if (!reg.IsMatch(word))
                    throw new Exception($"{name} code is Invalid. Can only contain letters");
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
        static public bool IsSentence(string str, string name)
        {
            bool success = true;
            try
            {
                // validates that sentence does not contain multiple spaces between words and has no numbers
                Regex reg = new Regex("^([a-zA-Z]+\\s)*[a-zA-Z]+$");
                if (str == "") throw new Exception($"{name} cannot be empty");
                if (!reg.IsMatch(str.TrimEnd()))
                    throw new Exception($"{name} is invalid. Can only contain letters and spaces!");
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
        static public bool CheckDate(DateTimePicker dtp, string name)
        {
            bool success = true;
            try
            {
                if (dtp.Value < DateTime.Now) throw new Exception($"{name} cannot be in the past");
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
            if (IsPresent(textBox))
            {
                int value;
                if (Int32.TryParse(textBox.Text, out value))
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
                    ShowInvalidInput(textBox, "must be a whole number.");
                    return false;
                }
            }
            else
            {
                return false;
            }
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
    }
}