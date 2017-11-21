﻿using System.Collections.Generic;
using XForm.Data;

namespace XForm.Query
{
    /// <summary>
    ///  XForm Queries are a set of stages built by IPipelineStageBuilders.
    ///  Create an IPipelineStageBuilder and specify the verbs it supports to extend the language.
    /// </summary>
    public interface IPipelineStageBuilder
    {
        /// <summary>
        ///  Set of command verbs which are built by this builder
        /// </summary>
        IEnumerable<string> Verbs { get; }

        /// <summary>
        ///  Usage message to write out for this command if it isn't passed the right parameters
        /// </summary>
        string Usage { get; }

        /// <summary>
        ///  Method to build the stage given a source and the parser. This code calls parser methods
        ///  in order to read the arguments required for this stage.
        /// </summary>
        /// <param name="source">IDataSourceEnumerator so far in this pipeline</param>
        /// <param name="parser">PipelineParser to use to read required arguments</param>
        /// <returns>IDataSourceEnumerator for the new stage</returns>
        IDataBatchEnumerator Build(IDataBatchEnumerator source, PipelineParser parser);
    }

}