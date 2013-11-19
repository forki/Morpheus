﻿using System.Collections.ObjectModel;
using System.Linq;
using IniConfig.Editor.lib.Contracts;
using IniConfig.Editor.lib.Models;
using IniConfig.lib;
using Microsoft.Practices.Prism.Events;

namespace IniConfig.Editor.lib.ViewModels
{
    public class DocumentViewModel : IViewModel
    {
        readonly EventAggregator _eventAggregator;

        public DocumentViewModel(EventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<DocumentChangedEventEvent>().Subscribe(OnDocumentChanged);

            Sections = new ObservableCollection<IniSection>();
            Entries = new ObservableCollection<IniEntry>();
        }

        public ObservableCollection<IniSection> Sections { get; set; }

        IniSection _currentSection;
        public IniSection CurrentSection
        {
            get { return _currentSection; }
            set
            {
                _currentSection = value;
                Entries.Clear();
                foreach(var entry in _currentSection.Entries)
                    Entries.Add(entry);
            }
        }

        public ObservableCollection<IniEntry> Entries { get; set; }

        void OnDocumentChanged(Document document)
        {
            Sections.Clear();
            foreach(var section in document.IniFile.Sections)
                Sections.Add(section);
        }
    }
}