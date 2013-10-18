﻿using System.IO;
using System.Linq;
using Machine.Fakes;
using Machine.Specifications;

namespace IniConfig.lib.Specs
{
    [Subject(typeof(IniFile))]
    internal class When_loading_not_existing_inifile : WithFakes
    {
        Because of = () => _error = Catch.Exception(() => IniFile.LoadFrom("NotExisting"));

        It should_fail_with_exception = () => _error.ShouldBeOfType(typeof(FileNotFoundException));

        static object _error;
    }


    [Subject(typeof(IniFile))]
    internal class When_loading_empty_inifile : WithSubject<IniFile>
    {
        Because of = () => Subject.LoadFromText("");

        It should_contain_one_line = () => Subject.Lines.Count.ShouldEqual(1);
        It should_not_contain_sections = () => Subject.Sections.ShouldBeEmpty();
    }


    [Subject(typeof(IniFile))]
    internal class When_loading_inifile_with_one_remark : WithSubject<IniFile>
    {
        Because of = () => Subject.LoadFromText("; Remarks");

        It should_contain_the_line = () => Subject.Lines.Count.ShouldEqual(1);
        It should_not_contain_sections = () => Subject.Sections.ShouldBeEmpty();
    }


    #region Sections

    [Subject(typeof(IniFile))]
    internal class When_loading_inifile_with_one_section : WithSubject<IniFile>
    {
        Because of = () => Subject.LoadFromText("[Section]");

        It should_contain_the_line = () => Subject.Lines.Count.ShouldEqual(1);
        It should_contain_the_section = () => Subject.Sections.Count.ShouldEqual(1);
    }


    [Subject(typeof(IniFile))]
    internal class When_loading_inifile_with_same_section_twice : WithSubject<IniFile>
    {
        const string IniText = "[Section]" + "\n" +
                               "[Section]";
        Because of = () => Subject.LoadFromText(IniText);

        It should_contain_two_lines = () => Subject.Lines.Count.ShouldEqual(2);
        It should_contain_one_sections = () => Subject.Sections.Count.ShouldEqual(1);
    }


    [Subject(typeof(IniFile))]
    internal class When_loading_inifile_with_section_with_remarks : WithSubject<IniFile>
    {
        const string IniText = "; Remarks" + "\n" +
                               "[Section]";
        Because of = () => Subject.LoadFromText(IniText);

        It should_contain_two_lines = () => Subject.Lines.Count.ShouldEqual(2);
        It should_contain_the_section = () => Subject.Sections.Count.ShouldEqual(1);
        It should_contain_the_remarks = () => Subject.Sections.First().Remarks.ShouldContainOnly("Remarks");
    }


    [Subject(typeof(IniFile))]
    internal class When_loading_inifile_with_section_with_remarks_separated_by_empty_lines : WithSubject<IniFile>
    {
        const string IniText = "; No Remarks" + "\n" +
            "\n" +
            "; Remarks" + "\n" +
            "[Section]";
        Because of = () => Subject.LoadFromText(IniText);

        It should_contain_four_lines = () => Subject.Lines.Count.ShouldEqual(4);
        It should_contain_remarks_only = () => Subject.Sections.First().Remarks.ShouldContainOnly("Remarks");
    }

    #endregion
}