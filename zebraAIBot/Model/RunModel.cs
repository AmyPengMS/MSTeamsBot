using System;

namespace MessageReaction.Model
{
    public class RunModel
    {
        //Optional Key (case/ICM/etc) for experiments which need it
        public string? DataSearchKey { get; set; } = "";
        //Optional OData SearchOptions for experiments which need it
        public DataSearchOptionsModel? DataSearchOptions { get; set; } = null;
        //ChatHistory object to store LLM chat history 
        public ChatHistory? ChatHistory { get; set; } = new ChatHistory();
        //used for language switch in translator experiments
        public string? TranslatorLanguage { get; set; } = null;
        //used for content in translator experiments
        public string? TranslatorContent { get; set; } = null;
        //Total tokens used by the LLM
        public int TotalTokens { get; set; } = 0;
        //Tokens used by the prompt
        public int PromptTokens { get; set; } = 0;
        //Tokens used by the completion
        public int CompletionTokens { get; set; } = 0;
        //Max number of rows to return when handling resultsets
        public int MaxNumberOfRows { get; set; } = 10;
        //Duration of the AI call in miliseconds
        public long AICallDuration { get; set; } = 0;
        //Duration of the search in miliseconds when search is used by experiment
        public long SearchDuration { get; set; } = 0;
        //CorrelationId for tracking purposes - this is your own - use when you want to track a specific call for reporting or integration
        public Guid? CorrelationId { get; set; } = null!;
    }

    /// <summary>
    /// Class to pass AI Search Options
    /// </summary>summary>
    public class DataSearchOptionsModel
    {
        public string SearchMode { get; set; } = "any";
        public string? Search { get; set; } = null;
        public string? Filter { get; set; } = null;
    }
}
