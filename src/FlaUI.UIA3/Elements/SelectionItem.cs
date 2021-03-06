﻿using FlaUI.UIA3.Patterns;
using System;
using FlaUI.Core.Exceptions;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Elements
{
    /// <summary>
    /// An UI-item which supports the <see cref="SelectionItemPattern"/>
    /// </summary>
    public class SelectionItem : Element
    {
        public SelectionItem(UIA3Automation automation, UIA.IUIAutomationElement nativeElement) : base(automation, nativeElement) { }

        public SelectionItemPattern SelectionItemPattern
        {
            get { return PatternFactory.GetSelectionItemPattern(); }
        }

        public bool IsSelected
        {
            get { return SelectionItemPattern.Current.IsSelected; }
            set
            {
                if (IsSelected == value) return;
                if (value && !IsSelected)
                {
                    Select();
                }
            }
        }

        public void Select()
        {
            var selectionItemPattern = SelectionItemPattern;
            if (selectionItemPattern == null)
            {
                throw new MethodNotSupportedException(String.Format("Select on '{0}' is not supported", ToString()));
            }
            selectionItemPattern.Select();
        }
    }
}
