using System;
using System.Data;
using System.Windows.Forms;

namespace Callculate_Sh
{
    public partial class Callculate : Form
    {
        public Callculate()
        {
            InitializeComponent();
        }

        // Обработчик изменения текста в textBox1 (можно оставить пустым, если не используется)
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        // Обработчик клика по кнопкам
        private void button_Click(object sender, EventArgs e)
        {
            // Проверяем, что событие вызвано кнопкой
            if (sender is Button currentButton)
            {
                // Добавляем текст кнопки в текстовое поле
                textBox1.Text += currentButton.Text;
            }
        }

        // Обработчик кнопки "C" (очистка)
        private void buttonClear_Click(object sender, EventArgs e)
        {
            // Очищаем текстовое поле
            textBox1.Text = "";
        }

        // Обработчик загрузки формы (можно оставить пустым, если не используется)
        private void Callculate_Load(object sender, EventArgs e)
        {
        }

        // Обработчик кнопки "=" (вычисление результата)
        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                // Используем DataTable для вычисления выражения
                var result = new DataTable();
                textBox1.Text = result.Compute(textBox1.Text, "").ToString();
            }
            catch (Exception ex)
            {
                // Выводим сообщение об ошибке, если выражение некорректно
                MessageBox.Show("Ошибка вычисления: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик ввода в текстовое поле
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Запрещаем ввод символов, которые не являются цифрами или допустимыми символами
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != '+' && number != '-' && number != '*' && number != '/' && number != '(' && number != ')' && number != '.' && number != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        // Обработчик кнопки "<<" (удаление последнего символа)
        private void buttonErese_Click(object sender, EventArgs e)
        {
            // Удаляем последний символ из текстового поля
            if (textBox1.Text.Length > 0)
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
        }
    }
}
