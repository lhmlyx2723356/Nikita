using System;

namespace Nikita.WinForm.ExtendControl
{
    /// <summary>
    /// Standard interface that has to be implemented by control's that
    /// should be diplayed in the dropdown area of the DropDownPanel.
    /// </summary>
    public interface IDropDownAware
    {
        #region Event Declarations

        /// <summary>
        /// Fired either on OK, Cancel or a click outside the control to indicate
        /// that the user has finished editing.
        /// </summary>
        event DropDownValueChangedEventHandler FinishEditing;

        /// <summary>
        /// Fired on any change of the controls's value during the editing process.
        /// </summary>
        event DropDownValueChangedEventHandler ValueChanged;

        #endregion Event Declarations

        #region Public Properties

        /// <summary>
        /// Gets or sets the controls' value.
        /// </summary>
        object Value { get; set; }

        #endregion Public Properties
    }
}