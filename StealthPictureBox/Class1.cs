using System.ComponentModel;

namespace StealthPictureBoxSpace
{
    [ToolboxItem(true)]
    public class StealthPictureBox : PictureBox
    {
        // Включение двойной буферизации
        public StealthPictureBox() : base()
        {
            this.DoubleBuffered = true;
        }
        private bool needRender = true;
        // Метод для отключения видимости объекта с сохранением его кликабельности
        public void StealthHide()
        {
            needRender = false;
            this.Invalidate(false);
        }
        // Метод для возвращения видимости объекта
        public void StealthShow()
        {
            needRender = true;
            this.Invalidate(false);
        }
        // Метод, возращающий true если объект скрыт спомощью StealthHide(), и false если объект не скрыт
        public bool IsHide()
        {
            return !needRender;
        }
        // Метод для смены видимости на противоположную
        public void StealthSwitch()
        {
            needRender = !needRender;
            this.Invalidate(false);
        }
        // Переопределение отрисовки объекта
        protected override void OnPaint(PaintEventArgs e)
        {
            if (needRender)
            {
                base.OnPaint(e);
            }
        }
    }
}