﻿// This file was auto-generated by ML.NET Model Builder. 
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
public partial class MLModel
{
    /// <summary>
    /// model input class for MLModel.
    /// </summary>
    #region model input class
    public class ModelInput
    {
        [ColumnName(@"userId")]
        public float UserId { get; set; }

        [ColumnName(@"movieId")]
        public float MovieId { get; set; }

        [ColumnName(@"rating")]
        public float Rating { get; set; }

        [ColumnName(@"timestamp")]
        public float Timestamp { get; set; }

    }

    #endregion

    /// <summary>
    /// model output class for MLModel.
    /// </summary>
    #region model output class
    public class ModelOutput
    {
        [ColumnName(@"userId")]
        public uint UserId { get; set; }

        [ColumnName(@"movieId")]
        public uint MovieId { get; set; }

        [ColumnName(@"rating")]
        public float Rating { get; set; }

        [ColumnName(@"timestamp")]
        public float Timestamp { get; set; }

        [ColumnName(@"Score")]
        public float Score { get; set; }

    }

    #endregion

    private static string MLNetModelPath = Path.GetFullPath("MLModel.zip");

    public static readonly Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(() => CreatePredictEngine(), true);

    /// <summary>
    /// Use this method to predict on <see cref="ModelInput"/>.
    /// </summary>
    /// <param name="input">model input.</param>
    /// <returns><seealso cref=" ModelOutput"/></returns>
    public static ModelOutput Predict(ModelInput input)
    {
        var predEngine = PredictEngine.Value;
        return predEngine.Predict(input);
    }

    private static PredictionEngine<ModelInput, ModelOutput> CreatePredictEngine()
    {
        var mlContext = new MLContext();
        ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var _);
        return mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
    }
}
