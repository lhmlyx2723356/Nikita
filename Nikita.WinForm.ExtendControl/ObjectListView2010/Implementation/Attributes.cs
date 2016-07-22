/*
 * Attributes - Attributes that can be attached to properties of models to allow columns to be
 *              built from them directly
 *
 * Author: Phillip Piper
 * Date: 15/08/2009 22:01
 *
 * Change log:
 * v2.6
 * 2012-08-16  JPP  - Added [OLVChildren] and [OLVIgnore]
 *                  - OLV attributes can now only be set on properties
 * v2.4
 * 2010-04-14  JPP  - Allow Name property to be set
 *
 * v2.3
 * 2009-08-15  JPP  - Initial version
 *
 * To do:
 *
 * Copyright (C) 2009-2014 Phillip Piper
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *
 * If you wish to use this code in a closed source application, please contact phillip_piper@bigfoot.com.
 */

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl
{
    /// <summary>
    /// Properties marked with [OLVChildren] will be used as the children source in a TreeListView.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class OLVChildrenAttribute : Attribute
    {
    }

    /// <summary>
    /// This attribute is used to mark a property of a model
    /// class that should be noticed by Generator class.
    /// </summary>
    /// <remarks>
    /// All the attributes of this class match their equivilent properties on OLVColumn.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Property)]
    public class OLVColumnAttribute : Attribute
    {
        #region Constructor

        // There are several property where we actually want nullable value (bool?, int?),
        // but it seems attribute properties can't be nullable types.
        // So we explicitly track if those properties have been set.

        /// <summary>
        /// Create a new OLVColumnAttribute
        /// </summary>
        public OLVColumnAttribute()
        {
        }

        /// <summary>
        /// Create a new OLVColumnAttribute with the given title
        /// </summary>
        /// <param name="title">The title of the column</param>
        public OLVColumnAttribute(string title)
        {
            this.Title = title;
        }

        #endregion Constructor

        #region Public properties

        internal bool IsCheckBoxesSet = false;

        internal bool IsEditableSet = false;

        internal bool IsFreeSpaceProportionSet = false;

        internal bool IsTextAlignSet = false;

        internal bool IsTriStateCheckBoxesSet = false;

        private string aspectToStringFormat;

        private bool checkBoxes;

        private int displayIndex = -1;

        private bool fillsFreeSpace;

        private int freeSpaceProportion;

        private object[] groupCutoffs;

        private string[] groupDescriptions;

        private string groupWithItemCountFormat;

        private string groupWithItemCountSingularFormat;

        private bool hyperlink;

        private string imageAspectName;

        private bool isEditable = true;

        private bool isTileViewColumn;

        private bool isVisible = true;

        private int maximumWidth = -1;

        private int minimumWidth = -1;

        private String name;

        private String tag;

        private HorizontalAlignment textAlign = HorizontalAlignment.Left;

        private String title;

        private String toolTipText;

        private bool triStateCheckBoxes;

        private bool useInitialLetterForGroup;

        private int width = 150;

        /// <summary>
        ///
        /// </summary>
        public string AspectToStringFormat
        {
            get { return aspectToStringFormat; }
            set { aspectToStringFormat = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public bool CheckBoxes
        {
            get { return checkBoxes; }
            set
            {
                checkBoxes = value;
                this.IsCheckBoxesSet = true;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public int DisplayIndex
        {
            get { return displayIndex; }
            set { displayIndex = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public bool FillsFreeSpace
        {
            get { return fillsFreeSpace; }
            set { fillsFreeSpace = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public int FreeSpaceProportion
        {
            get { return freeSpaceProportion; }
            set
            {
                freeSpaceProportion = value;
                IsFreeSpaceProportionSet = true;
            }
        }

        /// <summary>
        /// An array of IComparables that mark the cutoff points for values when
        /// grouping on this column.
        /// </summary>
        public object[] GroupCutoffs
        {
            get { return groupCutoffs; }
            set { groupCutoffs = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public string[] GroupDescriptions
        {
            get { return groupDescriptions; }
            set { groupDescriptions = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public string GroupWithItemCountFormat
        {
            get { return groupWithItemCountFormat; }
            set { groupWithItemCountFormat = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public string GroupWithItemCountSingularFormat
        {
            get { return groupWithItemCountSingularFormat; }
            set { groupWithItemCountSingularFormat = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public bool Hyperlink
        {
            get { return hyperlink; }
            set { hyperlink = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public string ImageAspectName
        {
            get { return imageAspectName; }
            set { imageAspectName = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public bool IsEditable
        {
            get { return isEditable; }
            set
            {
                isEditable = value;
                this.IsEditableSet = true;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public bool IsTileViewColumn
        {
            get { return isTileViewColumn; }
            set { isTileViewColumn = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public int MaximumWidth
        {
            get { return maximumWidth; }
            set { maximumWidth = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public int MinimumWidth
        {
            get { return minimumWidth; }
            set { minimumWidth = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public String Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public HorizontalAlignment TextAlign
        {
            get { return this.textAlign; }
            set
            {
                this.textAlign = value;
                IsTextAlignSet = true;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public String Title
        {
            get { return title; }
            set { title = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public String ToolTipText
        {
            get { return toolTipText; }
            set { toolTipText = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public bool TriStateCheckBoxes
        {
            get { return triStateCheckBoxes; }
            set
            {
                triStateCheckBoxes = value;
                this.IsTriStateCheckBoxesSet = true;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public bool UseInitialLetterForGroup
        {
            get { return useInitialLetterForGroup; }
            set { useInitialLetterForGroup = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        #endregion Public properties
    }

    /// <summary>
    /// Properties marked with [OLVIgnore] will not have columns generated for them.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class OLVIgnoreAttribute : Attribute
    {
    }
}