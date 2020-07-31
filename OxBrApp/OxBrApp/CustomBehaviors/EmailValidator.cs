﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace OxBrApp.CustomBehaviors
{
    public class EmailValidator : BehaviorBase<Entry>
    {
        const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        public static readonly BindableProperty IsValidProperty = BindableProperty.Create("IsValid", typeof(bool), typeof(EmailValidator), true);


        public bool IsValid
        {
            get { return (bool)base.GetValue(IsValidProperty); }
            set { base.SetValue(IsValidProperty, value); }
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.Unfocused += HandleUnFocused;
            bindable.Focused += HandleFocused;
        }

        /// <summary>
        /// Handles email validation and sets the text to red if wrong 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void HandleUnFocused(object sender, EventArgs e)
        {
            Entry thisEntry = ((Entry)sender);
            if (!String.IsNullOrEmpty(thisEntry.Text))
            {
                IsValid = (Regex.IsMatch(thisEntry.Text, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            }
            else
            {
                IsValid = false;
            }
            thisEntry.TextColor = IsValid ? Color.FromHex("66e6d9") : Color.Red;

        }

        void HandleFocused(object sender, EventArgs e)
        {
            ((Entry)sender).TextColor = Color.FromHex("66e6d9");
        }
        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);

            bindable.Unfocused -= HandleUnFocused;
            bindable.Focused -= HandleFocused;
        }
    }
}