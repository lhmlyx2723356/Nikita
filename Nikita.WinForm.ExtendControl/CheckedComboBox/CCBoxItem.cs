namespace Nikita.WinForm.ExtendControl
{
    public class CCBoxItem
    {
        public CCBoxItem()
        {
        }

        public CCBoxItem(string name, object val)
        {
            this.Name = name;
            this.Value = val;
        }

        public string Name { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return string.Format("name: '{0}', value: {1}", Name, Value);
        }
    }
}