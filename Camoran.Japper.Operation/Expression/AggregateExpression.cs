using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.Japper.Operation
{

    public class AggregateExpression
    {
        //Sum():AggregationPhrase
        //Avg():AggregationPhrase
        //Count():AggregationPhrase
        //Max():AggregationPhrase
        //Min():AggregationPhrase


        public AggregatePhrase Sum(SelectPhrase selectPhrase)
        {
            return new AggregatePhrase(
                selectPhrase.Name, 
                selectPhrase.Alias, 
                selectPhrase.TableName, 
                AggregateType.Sum);
        }

        public AggregatePhrase Avg(SelectPhrase selectPhrase)
        {
            return new AggregatePhrase(
                selectPhrase.Name,
                selectPhrase.Alias,
                selectPhrase.TableName,
                AggregateType.Avg);
        }

        public AggregatePhrase Count(SelectPhrase selectPhrase)
        {
            return new AggregatePhrase(
                selectPhrase.Name,
                selectPhrase.Alias,
                selectPhrase.TableName,
                AggregateType.Count);
        }

        public AggregatePhrase Max(SelectPhrase selectPhrase)
        {
            return new AggregatePhrase(
                selectPhrase.Name,
                selectPhrase.Alias,
                selectPhrase.TableName,
                AggregateType.Max);
        }

        public AggregatePhrase Min(SelectPhrase selectPhrase)
        {
            return new AggregatePhrase(
                selectPhrase.Name,
                selectPhrase.Alias,
                selectPhrase.TableName,
                AggregateType.Min);
        }

    }

}
