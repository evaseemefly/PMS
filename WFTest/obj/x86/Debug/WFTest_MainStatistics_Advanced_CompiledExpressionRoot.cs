namespace WFTest {
    
    #line 25 "E:\03协同开发\短信\PMS\PMS\WFTest\MainStatistics_Advanced.xaml"
    using System;
    
    #line default
    #line hidden
    
    #line 1 "E:\03协同开发\短信\PMS\PMS\WFTest\MainStatistics_Advanced.xaml"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 26 "E:\03协同开发\短信\PMS\PMS\WFTest\MainStatistics_Advanced.xaml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 1 "E:\03协同开发\短信\PMS\PMS\WFTest\MainStatistics_Advanced.xaml"
    using System.Activities;
    
    #line default
    #line hidden
    
    #line 1 "E:\03协同开发\短信\PMS\PMS\WFTest\MainStatistics_Advanced.xaml"
    using System.Activities.Expressions;
    
    #line default
    #line hidden
    
    #line 1 "E:\03协同开发\短信\PMS\PMS\WFTest\MainStatistics_Advanced.xaml"
    using System.Activities.Statements;
    
    #line default
    #line hidden
    
    #line 27 "E:\03协同开发\短信\PMS\PMS\WFTest\MainStatistics_Advanced.xaml"
    using System.Data;
    
    #line default
    #line hidden
    
    #line 28 "E:\03协同开发\短信\PMS\PMS\WFTest\MainStatistics_Advanced.xaml"
    using System.Linq;
    
    #line default
    #line hidden
    
    #line 29 "E:\03协同开发\短信\PMS\PMS\WFTest\MainStatistics_Advanced.xaml"
    using System.Text;
    
    #line default
    #line hidden
    
    #line 30 "E:\03协同开发\短信\PMS\PMS\WFTest\MainStatistics_Advanced.xaml"
    using PMS.Model.QueryModel;
    
    #line default
    #line hidden
    
    #line 1 "E:\03协同开发\短信\PMS\PMS\WFTest\MainStatistics_Advanced.xaml"
    using System.Activities.XamlIntegration;
    
    #line default
    #line hidden
    
    
    public partial class MainStatistics_Advanced : System.Activities.XamlIntegration.ICompiledExpressionRoot {
        
        private System.Activities.Activity rootActivity;
        
        private object dataContextActivities;
        
        private bool forImplementation = true;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string GetLanguage() {
            return "C#";
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public object InvokeExpression(int expressionId, System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext) {
            if ((this.rootActivity == null)) {
                this.rootActivity = this;
            }
            if ((this.dataContextActivities == null)) {
                this.dataContextActivities = MainStatistics_Advanced_TypedDataContext3.GetDataContextActivitiesHelper(this.rootActivity, this.forImplementation);
            }
            if ((expressionId == 0)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new MainStatistics_Advanced_TypedDataContext3(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext3 refDataContext0 = ((MainStatistics_Advanced_TypedDataContext3)(cachedCompiledDataContext[0]));
                return refDataContext0.GetLocation<string>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 1)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new MainStatistics_Advanced_TypedDataContext3(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext3 refDataContext1 = ((MainStatistics_Advanced_TypedDataContext3)(cachedCompiledDataContext[0]));
                return refDataContext1.GetLocation<string>(refDataContext1.ValueType___Expr1Get, refDataContext1.ValueType___Expr1Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 2)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new MainStatistics_Advanced_TypedDataContext3(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext3 refDataContext2 = ((MainStatistics_Advanced_TypedDataContext3)(cachedCompiledDataContext[0]));
                return refDataContext2.GetLocation<int>(refDataContext2.ValueType___Expr2Get, refDataContext2.ValueType___Expr2Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 3)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new MainStatistics_Advanced_TypedDataContext3(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext3 refDataContext3 = ((MainStatistics_Advanced_TypedDataContext3)(cachedCompiledDataContext[0]));
                return refDataContext3.GetLocation<string>(refDataContext3.ValueType___Expr3Get, refDataContext3.ValueType___Expr3Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 4)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new MainStatistics_Advanced_TypedDataContext3(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext3 refDataContext4 = ((MainStatistics_Advanced_TypedDataContext3)(cachedCompiledDataContext[0]));
                return refDataContext4.GetLocation<double>(refDataContext4.ValueType___Expr4Get, refDataContext4.ValueType___Expr4Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 5)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext6.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new MainStatistics_Advanced_TypedDataContext6(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext6 refDataContext5 = ((MainStatistics_Advanced_TypedDataContext6)(cachedCompiledDataContext[1]));
                return refDataContext5.GetLocation<System.Collections.Generic.List<PMS.Model.QueryModel.Redis_SMSContent>>(refDataContext5.ValueType___Expr5Get, refDataContext5.ValueType___Expr5Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 6)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext6_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new MainStatistics_Advanced_TypedDataContext6_ForReadOnly(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext6_ForReadOnly valDataContext6 = ((MainStatistics_Advanced_TypedDataContext6_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext6.ValueType___Expr6Get();
            }
            if ((expressionId == 7)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext6_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new MainStatistics_Advanced_TypedDataContext6_ForReadOnly(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext6_ForReadOnly valDataContext7 = ((MainStatistics_Advanced_TypedDataContext6_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext7.ValueType___Expr7Get();
            }
            if ((expressionId == 8)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext5_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new MainStatistics_Advanced_TypedDataContext5_ForReadOnly(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext5_ForReadOnly valDataContext8 = ((MainStatistics_Advanced_TypedDataContext5_ForReadOnly)(cachedCompiledDataContext[3]));
                return valDataContext8.ValueType___Expr8Get();
            }
            if ((expressionId == 9)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext5_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new MainStatistics_Advanced_TypedDataContext5_ForReadOnly(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext5_ForReadOnly valDataContext9 = ((MainStatistics_Advanced_TypedDataContext5_ForReadOnly)(cachedCompiledDataContext[3]));
                return valDataContext9.ValueType___Expr9Get();
            }
            if ((expressionId == 10)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext9_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new MainStatistics_Advanced_TypedDataContext9_ForReadOnly(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext9_ForReadOnly valDataContext10 = ((MainStatistics_Advanced_TypedDataContext9_ForReadOnly)(cachedCompiledDataContext[4]));
                return valDataContext10.ValueType___Expr10Get();
            }
            if ((expressionId == 11)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext9.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new MainStatistics_Advanced_TypedDataContext9(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext9 refDataContext11 = ((MainStatistics_Advanced_TypedDataContext9)(cachedCompiledDataContext[5]));
                return refDataContext11.GetLocation<int>(refDataContext11.ValueType___Expr11Get, refDataContext11.ValueType___Expr11Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 12)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext9_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new MainStatistics_Advanced_TypedDataContext9_ForReadOnly(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext9_ForReadOnly valDataContext12 = ((MainStatistics_Advanced_TypedDataContext9_ForReadOnly)(cachedCompiledDataContext[4]));
                return valDataContext12.ValueType___Expr12Get();
            }
            if ((expressionId == 13)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext9_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new MainStatistics_Advanced_TypedDataContext9_ForReadOnly(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext9_ForReadOnly valDataContext13 = ((MainStatistics_Advanced_TypedDataContext9_ForReadOnly)(cachedCompiledDataContext[4]));
                return valDataContext13.ValueType___Expr13Get();
            }
            if ((expressionId == 14)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext9.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new MainStatistics_Advanced_TypedDataContext9(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext9 refDataContext14 = ((MainStatistics_Advanced_TypedDataContext9)(cachedCompiledDataContext[5]));
                return refDataContext14.GetLocation<string>(refDataContext14.ValueType___Expr14Get, refDataContext14.ValueType___Expr14Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 15)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext9.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new MainStatistics_Advanced_TypedDataContext9(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext9 refDataContext15 = ((MainStatistics_Advanced_TypedDataContext9)(cachedCompiledDataContext[5]));
                return refDataContext15.GetLocation<PMS.Model.QueryModel.Redis_SMSContent>(refDataContext15.ValueType___Expr15Get, refDataContext15.ValueType___Expr15Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 16)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext8_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[6] == null)) {
                    cachedCompiledDataContext[6] = new MainStatistics_Advanced_TypedDataContext8_ForReadOnly(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext8_ForReadOnly valDataContext16 = ((MainStatistics_Advanced_TypedDataContext8_ForReadOnly)(cachedCompiledDataContext[6]));
                return valDataContext16.ValueType___Expr16Get();
            }
            if ((expressionId == 17)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext8_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[6] == null)) {
                    cachedCompiledDataContext[6] = new MainStatistics_Advanced_TypedDataContext8_ForReadOnly(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext8_ForReadOnly valDataContext17 = ((MainStatistics_Advanced_TypedDataContext8_ForReadOnly)(cachedCompiledDataContext[6]));
                return valDataContext17.ValueType___Expr17Get();
            }
            if ((expressionId == 18)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext10_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[7] == null)) {
                    cachedCompiledDataContext[7] = new MainStatistics_Advanced_TypedDataContext10_ForReadOnly(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext10_ForReadOnly valDataContext18 = ((MainStatistics_Advanced_TypedDataContext10_ForReadOnly)(cachedCompiledDataContext[7]));
                return valDataContext18.ValueType___Expr18Get();
            }
            if ((expressionId == 19)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext10_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[7] == null)) {
                    cachedCompiledDataContext[7] = new MainStatistics_Advanced_TypedDataContext10_ForReadOnly(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext10_ForReadOnly valDataContext19 = ((MainStatistics_Advanced_TypedDataContext10_ForReadOnly)(cachedCompiledDataContext[7]));
                return valDataContext19.ValueType___Expr19Get();
            }
            if ((expressionId == 20)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext10_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[7] == null)) {
                    cachedCompiledDataContext[7] = new MainStatistics_Advanced_TypedDataContext10_ForReadOnly(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext10_ForReadOnly valDataContext20 = ((MainStatistics_Advanced_TypedDataContext10_ForReadOnly)(cachedCompiledDataContext[7]));
                return valDataContext20.ValueType___Expr20Get();
            }
            if ((expressionId == 21)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext10.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[8] == null)) {
                    cachedCompiledDataContext[8] = new MainStatistics_Advanced_TypedDataContext10(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext10 refDataContext21 = ((MainStatistics_Advanced_TypedDataContext10)(cachedCompiledDataContext[8]));
                return refDataContext21.GetLocation<System.Collections.Generic.List<PMS.Model.SMSModel.SMSModel_QueryReceive>>(refDataContext21.ValueType___Expr21Get, refDataContext21.ValueType___Expr21Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 22)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext10.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[8] == null)) {
                    cachedCompiledDataContext[8] = new MainStatistics_Advanced_TypedDataContext10(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext10 refDataContext22 = ((MainStatistics_Advanced_TypedDataContext10)(cachedCompiledDataContext[8]));
                return refDataContext22.GetLocation<int>(refDataContext22.ValueType___Expr22Get, refDataContext22.ValueType___Expr22Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 23)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext10_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[7] == null)) {
                    cachedCompiledDataContext[7] = new MainStatistics_Advanced_TypedDataContext10_ForReadOnly(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext10_ForReadOnly valDataContext23 = ((MainStatistics_Advanced_TypedDataContext10_ForReadOnly)(cachedCompiledDataContext[7]));
                return valDataContext23.ValueType___Expr23Get();
            }
            if ((expressionId == 24)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext10_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[7] == null)) {
                    cachedCompiledDataContext[7] = new MainStatistics_Advanced_TypedDataContext10_ForReadOnly(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext10_ForReadOnly valDataContext24 = ((MainStatistics_Advanced_TypedDataContext10_ForReadOnly)(cachedCompiledDataContext[7]));
                return valDataContext24.ValueType___Expr24Get();
            }
            if ((expressionId == 25)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext10_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[7] == null)) {
                    cachedCompiledDataContext[7] = new MainStatistics_Advanced_TypedDataContext10_ForReadOnly(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext10_ForReadOnly valDataContext25 = ((MainStatistics_Advanced_TypedDataContext10_ForReadOnly)(cachedCompiledDataContext[7]));
                return valDataContext25.ValueType___Expr25Get();
            }
            if ((expressionId == 26)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext10_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[7] == null)) {
                    cachedCompiledDataContext[7] = new MainStatistics_Advanced_TypedDataContext10_ForReadOnly(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext10_ForReadOnly valDataContext26 = ((MainStatistics_Advanced_TypedDataContext10_ForReadOnly)(cachedCompiledDataContext[7]));
                return valDataContext26.ValueType___Expr26Get();
            }
            if ((expressionId == 27)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext10_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[7] == null)) {
                    cachedCompiledDataContext[7] = new MainStatistics_Advanced_TypedDataContext10_ForReadOnly(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext10_ForReadOnly valDataContext27 = ((MainStatistics_Advanced_TypedDataContext10_ForReadOnly)(cachedCompiledDataContext[7]));
                return valDataContext27.ValueType___Expr27Get();
            }
            if ((expressionId == 28)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext11_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[9] == null)) {
                    cachedCompiledDataContext[9] = new MainStatistics_Advanced_TypedDataContext11_ForReadOnly(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext11_ForReadOnly valDataContext28 = ((MainStatistics_Advanced_TypedDataContext11_ForReadOnly)(cachedCompiledDataContext[9]));
                return valDataContext28.ValueType___Expr28Get();
            }
            if ((expressionId == 29)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext11.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[10] == null)) {
                    cachedCompiledDataContext[10] = new MainStatistics_Advanced_TypedDataContext11(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext11 refDataContext29 = ((MainStatistics_Advanced_TypedDataContext11)(cachedCompiledDataContext[10]));
                return refDataContext29.GetLocation<int>(refDataContext29.ValueType___Expr29Get, refDataContext29.ValueType___Expr29Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 30)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext11.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[10] == null)) {
                    cachedCompiledDataContext[10] = new MainStatistics_Advanced_TypedDataContext11(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext11 refDataContext30 = ((MainStatistics_Advanced_TypedDataContext11)(cachedCompiledDataContext[10]));
                return refDataContext30.GetLocation<string>(refDataContext30.ValueType___Expr30Get, refDataContext30.ValueType___Expr30Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 31)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext11_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[9] == null)) {
                    cachedCompiledDataContext[9] = new MainStatistics_Advanced_TypedDataContext11_ForReadOnly(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext11_ForReadOnly valDataContext31 = ((MainStatistics_Advanced_TypedDataContext11_ForReadOnly)(cachedCompiledDataContext[9]));
                return valDataContext31.ValueType___Expr31Get();
            }
            if ((expressionId == 32)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext11.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[10] == null)) {
                    cachedCompiledDataContext[10] = new MainStatistics_Advanced_TypedDataContext11(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext11 refDataContext32 = ((MainStatistics_Advanced_TypedDataContext11)(cachedCompiledDataContext[10]));
                return refDataContext32.GetLocation<string>(refDataContext32.ValueType___Expr32Get, refDataContext32.ValueType___Expr32Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 33)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext11.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[10] == null)) {
                    cachedCompiledDataContext[10] = new MainStatistics_Advanced_TypedDataContext11(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext11 refDataContext33 = ((MainStatistics_Advanced_TypedDataContext11)(cachedCompiledDataContext[10]));
                return refDataContext33.GetLocation<int>(refDataContext33.ValueType___Expr33Get, refDataContext33.ValueType___Expr33Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 34)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext11_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[9] == null)) {
                    cachedCompiledDataContext[9] = new MainStatistics_Advanced_TypedDataContext11_ForReadOnly(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext11_ForReadOnly valDataContext34 = ((MainStatistics_Advanced_TypedDataContext11_ForReadOnly)(cachedCompiledDataContext[9]));
                return valDataContext34.ValueType___Expr34Get();
            }
            if ((expressionId == 35)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext11_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[9] == null)) {
                    cachedCompiledDataContext[9] = new MainStatistics_Advanced_TypedDataContext11_ForReadOnly(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext11_ForReadOnly valDataContext35 = ((MainStatistics_Advanced_TypedDataContext11_ForReadOnly)(cachedCompiledDataContext[9]));
                return valDataContext35.ValueType___Expr35Get();
            }
            if ((expressionId == 36)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext11_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[9] == null)) {
                    cachedCompiledDataContext[9] = new MainStatistics_Advanced_TypedDataContext11_ForReadOnly(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext11_ForReadOnly valDataContext36 = ((MainStatistics_Advanced_TypedDataContext11_ForReadOnly)(cachedCompiledDataContext[9]));
                return valDataContext36.ValueType___Expr36Get();
            }
            if ((expressionId == 37)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext11_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[9] == null)) {
                    cachedCompiledDataContext[9] = new MainStatistics_Advanced_TypedDataContext11_ForReadOnly(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext11_ForReadOnly valDataContext37 = ((MainStatistics_Advanced_TypedDataContext11_ForReadOnly)(cachedCompiledDataContext[9]));
                return valDataContext37.ValueType___Expr37Get();
            }
            if ((expressionId == 38)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext11_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[9] == null)) {
                    cachedCompiledDataContext[9] = new MainStatistics_Advanced_TypedDataContext11_ForReadOnly(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext11_ForReadOnly valDataContext38 = ((MainStatistics_Advanced_TypedDataContext11_ForReadOnly)(cachedCompiledDataContext[9]));
                return valDataContext38.ValueType___Expr38Get();
            }
            if ((expressionId == 39)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext11_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[9] == null)) {
                    cachedCompiledDataContext[9] = new MainStatistics_Advanced_TypedDataContext11_ForReadOnly(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext11_ForReadOnly valDataContext39 = ((MainStatistics_Advanced_TypedDataContext11_ForReadOnly)(cachedCompiledDataContext[9]));
                return valDataContext39.ValueType___Expr39Get();
            }
            if ((expressionId == 40)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MainStatistics_Advanced_TypedDataContext12_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 12);
                if ((cachedCompiledDataContext[11] == null)) {
                    cachedCompiledDataContext[11] = new MainStatistics_Advanced_TypedDataContext12_ForReadOnly(locations, activityContext, true);
                }
                MainStatistics_Advanced_TypedDataContext12_ForReadOnly valDataContext40 = ((MainStatistics_Advanced_TypedDataContext12_ForReadOnly)(cachedCompiledDataContext[11]));
                return valDataContext40.ValueType___Expr40Get();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public object InvokeExpression(int expressionId, System.Collections.Generic.IList<System.Activities.Location> locations) {
            if ((this.rootActivity == null)) {
                this.rootActivity = this;
            }
            if ((expressionId == 0)) {
                MainStatistics_Advanced_TypedDataContext3 refDataContext0 = new MainStatistics_Advanced_TypedDataContext3(locations, true);
                return refDataContext0.GetLocation<string>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set);
            }
            if ((expressionId == 1)) {
                MainStatistics_Advanced_TypedDataContext3 refDataContext1 = new MainStatistics_Advanced_TypedDataContext3(locations, true);
                return refDataContext1.GetLocation<string>(refDataContext1.ValueType___Expr1Get, refDataContext1.ValueType___Expr1Set);
            }
            if ((expressionId == 2)) {
                MainStatistics_Advanced_TypedDataContext3 refDataContext2 = new MainStatistics_Advanced_TypedDataContext3(locations, true);
                return refDataContext2.GetLocation<int>(refDataContext2.ValueType___Expr2Get, refDataContext2.ValueType___Expr2Set);
            }
            if ((expressionId == 3)) {
                MainStatistics_Advanced_TypedDataContext3 refDataContext3 = new MainStatistics_Advanced_TypedDataContext3(locations, true);
                return refDataContext3.GetLocation<string>(refDataContext3.ValueType___Expr3Get, refDataContext3.ValueType___Expr3Set);
            }
            if ((expressionId == 4)) {
                MainStatistics_Advanced_TypedDataContext3 refDataContext4 = new MainStatistics_Advanced_TypedDataContext3(locations, true);
                return refDataContext4.GetLocation<double>(refDataContext4.ValueType___Expr4Get, refDataContext4.ValueType___Expr4Set);
            }
            if ((expressionId == 5)) {
                MainStatistics_Advanced_TypedDataContext6 refDataContext5 = new MainStatistics_Advanced_TypedDataContext6(locations, true);
                return refDataContext5.GetLocation<System.Collections.Generic.List<PMS.Model.QueryModel.Redis_SMSContent>>(refDataContext5.ValueType___Expr5Get, refDataContext5.ValueType___Expr5Set);
            }
            if ((expressionId == 6)) {
                MainStatistics_Advanced_TypedDataContext6_ForReadOnly valDataContext6 = new MainStatistics_Advanced_TypedDataContext6_ForReadOnly(locations, true);
                return valDataContext6.ValueType___Expr6Get();
            }
            if ((expressionId == 7)) {
                MainStatistics_Advanced_TypedDataContext6_ForReadOnly valDataContext7 = new MainStatistics_Advanced_TypedDataContext6_ForReadOnly(locations, true);
                return valDataContext7.ValueType___Expr7Get();
            }
            if ((expressionId == 8)) {
                MainStatistics_Advanced_TypedDataContext5_ForReadOnly valDataContext8 = new MainStatistics_Advanced_TypedDataContext5_ForReadOnly(locations, true);
                return valDataContext8.ValueType___Expr8Get();
            }
            if ((expressionId == 9)) {
                MainStatistics_Advanced_TypedDataContext5_ForReadOnly valDataContext9 = new MainStatistics_Advanced_TypedDataContext5_ForReadOnly(locations, true);
                return valDataContext9.ValueType___Expr9Get();
            }
            if ((expressionId == 10)) {
                MainStatistics_Advanced_TypedDataContext9_ForReadOnly valDataContext10 = new MainStatistics_Advanced_TypedDataContext9_ForReadOnly(locations, true);
                return valDataContext10.ValueType___Expr10Get();
            }
            if ((expressionId == 11)) {
                MainStatistics_Advanced_TypedDataContext9 refDataContext11 = new MainStatistics_Advanced_TypedDataContext9(locations, true);
                return refDataContext11.GetLocation<int>(refDataContext11.ValueType___Expr11Get, refDataContext11.ValueType___Expr11Set);
            }
            if ((expressionId == 12)) {
                MainStatistics_Advanced_TypedDataContext9_ForReadOnly valDataContext12 = new MainStatistics_Advanced_TypedDataContext9_ForReadOnly(locations, true);
                return valDataContext12.ValueType___Expr12Get();
            }
            if ((expressionId == 13)) {
                MainStatistics_Advanced_TypedDataContext9_ForReadOnly valDataContext13 = new MainStatistics_Advanced_TypedDataContext9_ForReadOnly(locations, true);
                return valDataContext13.ValueType___Expr13Get();
            }
            if ((expressionId == 14)) {
                MainStatistics_Advanced_TypedDataContext9 refDataContext14 = new MainStatistics_Advanced_TypedDataContext9(locations, true);
                return refDataContext14.GetLocation<string>(refDataContext14.ValueType___Expr14Get, refDataContext14.ValueType___Expr14Set);
            }
            if ((expressionId == 15)) {
                MainStatistics_Advanced_TypedDataContext9 refDataContext15 = new MainStatistics_Advanced_TypedDataContext9(locations, true);
                return refDataContext15.GetLocation<PMS.Model.QueryModel.Redis_SMSContent>(refDataContext15.ValueType___Expr15Get, refDataContext15.ValueType___Expr15Set);
            }
            if ((expressionId == 16)) {
                MainStatistics_Advanced_TypedDataContext8_ForReadOnly valDataContext16 = new MainStatistics_Advanced_TypedDataContext8_ForReadOnly(locations, true);
                return valDataContext16.ValueType___Expr16Get();
            }
            if ((expressionId == 17)) {
                MainStatistics_Advanced_TypedDataContext8_ForReadOnly valDataContext17 = new MainStatistics_Advanced_TypedDataContext8_ForReadOnly(locations, true);
                return valDataContext17.ValueType___Expr17Get();
            }
            if ((expressionId == 18)) {
                MainStatistics_Advanced_TypedDataContext10_ForReadOnly valDataContext18 = new MainStatistics_Advanced_TypedDataContext10_ForReadOnly(locations, true);
                return valDataContext18.ValueType___Expr18Get();
            }
            if ((expressionId == 19)) {
                MainStatistics_Advanced_TypedDataContext10_ForReadOnly valDataContext19 = new MainStatistics_Advanced_TypedDataContext10_ForReadOnly(locations, true);
                return valDataContext19.ValueType___Expr19Get();
            }
            if ((expressionId == 20)) {
                MainStatistics_Advanced_TypedDataContext10_ForReadOnly valDataContext20 = new MainStatistics_Advanced_TypedDataContext10_ForReadOnly(locations, true);
                return valDataContext20.ValueType___Expr20Get();
            }
            if ((expressionId == 21)) {
                MainStatistics_Advanced_TypedDataContext10 refDataContext21 = new MainStatistics_Advanced_TypedDataContext10(locations, true);
                return refDataContext21.GetLocation<System.Collections.Generic.List<PMS.Model.SMSModel.SMSModel_QueryReceive>>(refDataContext21.ValueType___Expr21Get, refDataContext21.ValueType___Expr21Set);
            }
            if ((expressionId == 22)) {
                MainStatistics_Advanced_TypedDataContext10 refDataContext22 = new MainStatistics_Advanced_TypedDataContext10(locations, true);
                return refDataContext22.GetLocation<int>(refDataContext22.ValueType___Expr22Get, refDataContext22.ValueType___Expr22Set);
            }
            if ((expressionId == 23)) {
                MainStatistics_Advanced_TypedDataContext10_ForReadOnly valDataContext23 = new MainStatistics_Advanced_TypedDataContext10_ForReadOnly(locations, true);
                return valDataContext23.ValueType___Expr23Get();
            }
            if ((expressionId == 24)) {
                MainStatistics_Advanced_TypedDataContext10_ForReadOnly valDataContext24 = new MainStatistics_Advanced_TypedDataContext10_ForReadOnly(locations, true);
                return valDataContext24.ValueType___Expr24Get();
            }
            if ((expressionId == 25)) {
                MainStatistics_Advanced_TypedDataContext10_ForReadOnly valDataContext25 = new MainStatistics_Advanced_TypedDataContext10_ForReadOnly(locations, true);
                return valDataContext25.ValueType___Expr25Get();
            }
            if ((expressionId == 26)) {
                MainStatistics_Advanced_TypedDataContext10_ForReadOnly valDataContext26 = new MainStatistics_Advanced_TypedDataContext10_ForReadOnly(locations, true);
                return valDataContext26.ValueType___Expr26Get();
            }
            if ((expressionId == 27)) {
                MainStatistics_Advanced_TypedDataContext10_ForReadOnly valDataContext27 = new MainStatistics_Advanced_TypedDataContext10_ForReadOnly(locations, true);
                return valDataContext27.ValueType___Expr27Get();
            }
            if ((expressionId == 28)) {
                MainStatistics_Advanced_TypedDataContext11_ForReadOnly valDataContext28 = new MainStatistics_Advanced_TypedDataContext11_ForReadOnly(locations, true);
                return valDataContext28.ValueType___Expr28Get();
            }
            if ((expressionId == 29)) {
                MainStatistics_Advanced_TypedDataContext11 refDataContext29 = new MainStatistics_Advanced_TypedDataContext11(locations, true);
                return refDataContext29.GetLocation<int>(refDataContext29.ValueType___Expr29Get, refDataContext29.ValueType___Expr29Set);
            }
            if ((expressionId == 30)) {
                MainStatistics_Advanced_TypedDataContext11 refDataContext30 = new MainStatistics_Advanced_TypedDataContext11(locations, true);
                return refDataContext30.GetLocation<string>(refDataContext30.ValueType___Expr30Get, refDataContext30.ValueType___Expr30Set);
            }
            if ((expressionId == 31)) {
                MainStatistics_Advanced_TypedDataContext11_ForReadOnly valDataContext31 = new MainStatistics_Advanced_TypedDataContext11_ForReadOnly(locations, true);
                return valDataContext31.ValueType___Expr31Get();
            }
            if ((expressionId == 32)) {
                MainStatistics_Advanced_TypedDataContext11 refDataContext32 = new MainStatistics_Advanced_TypedDataContext11(locations, true);
                return refDataContext32.GetLocation<string>(refDataContext32.ValueType___Expr32Get, refDataContext32.ValueType___Expr32Set);
            }
            if ((expressionId == 33)) {
                MainStatistics_Advanced_TypedDataContext11 refDataContext33 = new MainStatistics_Advanced_TypedDataContext11(locations, true);
                return refDataContext33.GetLocation<int>(refDataContext33.ValueType___Expr33Get, refDataContext33.ValueType___Expr33Set);
            }
            if ((expressionId == 34)) {
                MainStatistics_Advanced_TypedDataContext11_ForReadOnly valDataContext34 = new MainStatistics_Advanced_TypedDataContext11_ForReadOnly(locations, true);
                return valDataContext34.ValueType___Expr34Get();
            }
            if ((expressionId == 35)) {
                MainStatistics_Advanced_TypedDataContext11_ForReadOnly valDataContext35 = new MainStatistics_Advanced_TypedDataContext11_ForReadOnly(locations, true);
                return valDataContext35.ValueType___Expr35Get();
            }
            if ((expressionId == 36)) {
                MainStatistics_Advanced_TypedDataContext11_ForReadOnly valDataContext36 = new MainStatistics_Advanced_TypedDataContext11_ForReadOnly(locations, true);
                return valDataContext36.ValueType___Expr36Get();
            }
            if ((expressionId == 37)) {
                MainStatistics_Advanced_TypedDataContext11_ForReadOnly valDataContext37 = new MainStatistics_Advanced_TypedDataContext11_ForReadOnly(locations, true);
                return valDataContext37.ValueType___Expr37Get();
            }
            if ((expressionId == 38)) {
                MainStatistics_Advanced_TypedDataContext11_ForReadOnly valDataContext38 = new MainStatistics_Advanced_TypedDataContext11_ForReadOnly(locations, true);
                return valDataContext38.ValueType___Expr38Get();
            }
            if ((expressionId == 39)) {
                MainStatistics_Advanced_TypedDataContext11_ForReadOnly valDataContext39 = new MainStatistics_Advanced_TypedDataContext11_ForReadOnly(locations, true);
                return valDataContext39.ValueType___Expr39Get();
            }
            if ((expressionId == 40)) {
                MainStatistics_Advanced_TypedDataContext12_ForReadOnly valDataContext40 = new MainStatistics_Advanced_TypedDataContext12_ForReadOnly(locations, true);
                return valDataContext40.ValueType___Expr40Get();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool CanExecuteExpression(string expressionText, bool isReference, System.Collections.Generic.IList<System.Activities.LocationReference> locations, out int expressionId) {
            if (((isReference == true) 
                        && ((expressionText == "_id_hash") 
                        && (MainStatistics_Advanced_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 0;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "_id_list_msgid") 
                        && (MainStatistics_Advanced_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 1;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "_sleepTime") 
                        && (MainStatistics_Advanced_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 2;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "_id_list") 
                        && (MainStatistics_Advanced_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 3;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "_secs_interval") 
                        && (MainStatistics_Advanced_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 4;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "_list_redis") 
                        && (MainStatistics_Advanced_TypedDataContext6.Validate(locations, true, 0) == true)))) {
                expressionId = 5;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "_secs_interval") 
                        && (MainStatistics_Advanced_TypedDataContext6_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 6;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "_id_list") 
                        && (MainStatistics_Advanced_TypedDataContext6_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 7;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "_list_redis.Count>0") 
                        && (MainStatistics_Advanced_TypedDataContext5_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 8;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "_list_redis.Count==0") 
                        && (MainStatistics_Advanced_TypedDataContext5_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 9;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "_list_redis") 
                        && (MainStatistics_Advanced_TypedDataContext9_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 10;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "_result") 
                        && (MainStatistics_Advanced_TypedDataContext9.Validate(locations, true, 0) == true)))) {
                expressionId = 11;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "_secs_interval") 
                        && (MainStatistics_Advanced_TypedDataContext9_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 12;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "_id_list") 
                        && (MainStatistics_Advanced_TypedDataContext9_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 13;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "_first_msgid") 
                        && (MainStatistics_Advanced_TypedDataContext9.Validate(locations, true, 0) == true)))) {
                expressionId = 14;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "_query_obj") 
                        && (MainStatistics_Advanced_TypedDataContext9.Validate(locations, true, 0) == true)))) {
                expressionId = 15;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "_query_obj.msgid != string.Empty&&_result==1") 
                        && (MainStatistics_Advanced_TypedDataContext8_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 16;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "_result==3") 
                        && (MainStatistics_Advanced_TypedDataContext8_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 17;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "_state==0") 
                        && (MainStatistics_Advanced_TypedDataContext10_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 18;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "_query_obj") 
                        && (MainStatistics_Advanced_TypedDataContext10_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 19;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "_first_msgid") 
                        && (MainStatistics_Advanced_TypedDataContext10_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 20;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "_list_queryReceive") 
                        && (MainStatistics_Advanced_TypedDataContext10.Validate(locations, true, 0) == true)))) {
                expressionId = 21;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "_state") 
                        && (MainStatistics_Advanced_TypedDataContext10.Validate(locations, true, 0) == true)))) {
                expressionId = 22;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "_sleepTime") 
                        && (MainStatistics_Advanced_TypedDataContext10_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 23;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "\"此时状态码为\"+_state") 
                        && (MainStatistics_Advanced_TypedDataContext10_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 24;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "(_state==1||_state==2)&&_result!=4") 
                        && (MainStatistics_Advanced_TypedDataContext10_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 25;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "_result==4") 
                        && (MainStatistics_Advanced_TypedDataContext10_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 26;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "\"状态码为\"+_result+\"工作流被挂起\"") 
                        && (MainStatistics_Advanced_TypedDataContext10_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 27;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "_id_hash") 
                        && (MainStatistics_Advanced_TypedDataContext11_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 28;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "_result") 
                        && (MainStatistics_Advanced_TypedDataContext11.Validate(locations, true, 0) == true)))) {
                expressionId = 29;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "TempBookMarkName") 
                        && (MainStatistics_Advanced_TypedDataContext11.Validate(locations, true, 0) == true)))) {
                expressionId = 30;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "_id_list_msgid") 
                        && (MainStatistics_Advanced_TypedDataContext11_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 31;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "_first_msgid") 
                        && (MainStatistics_Advanced_TypedDataContext11.Validate(locations, true, 0) == true)))) {
                expressionId = 32;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "_state") 
                        && (MainStatistics_Advanced_TypedDataContext11.Validate(locations, true, 0) == true)))) {
                expressionId = 33;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "\"书签中的state为\"+_state") 
                        && (MainStatistics_Advanced_TypedDataContext11_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 34;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "\"书签中的result为\"+_result") 
                        && (MainStatistics_Advanced_TypedDataContext11_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 35;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "\"该书签恢复的MsgId为\"+_first_msgid") 
                        && (MainStatistics_Advanced_TypedDataContext11_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 36;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "_result==4") 
                        && (MainStatistics_Advanced_TypedDataContext11_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 37;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "_result==6") 
                        && (MainStatistics_Advanced_TypedDataContext11_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 38;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "\"resut为\"+_result") 
                        && (MainStatistics_Advanced_TypedDataContext11_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 39;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "_result==6") 
                        && (MainStatistics_Advanced_TypedDataContext12_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 40;
                return true;
            }
            expressionId = -1;
            return false;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IList<string> GetRequiredLocations(int expressionId) {
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Linq.Expressions.Expression GetExpressionTreeForExpression(int expressionId, System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) {
            if ((expressionId == 0)) {
                return new MainStatistics_Advanced_TypedDataContext3(locationReferences).@__Expr0GetTree();
            }
            if ((expressionId == 1)) {
                return new MainStatistics_Advanced_TypedDataContext3(locationReferences).@__Expr1GetTree();
            }
            if ((expressionId == 2)) {
                return new MainStatistics_Advanced_TypedDataContext3(locationReferences).@__Expr2GetTree();
            }
            if ((expressionId == 3)) {
                return new MainStatistics_Advanced_TypedDataContext3(locationReferences).@__Expr3GetTree();
            }
            if ((expressionId == 4)) {
                return new MainStatistics_Advanced_TypedDataContext3(locationReferences).@__Expr4GetTree();
            }
            if ((expressionId == 5)) {
                return new MainStatistics_Advanced_TypedDataContext6(locationReferences).@__Expr5GetTree();
            }
            if ((expressionId == 6)) {
                return new MainStatistics_Advanced_TypedDataContext6_ForReadOnly(locationReferences).@__Expr6GetTree();
            }
            if ((expressionId == 7)) {
                return new MainStatistics_Advanced_TypedDataContext6_ForReadOnly(locationReferences).@__Expr7GetTree();
            }
            if ((expressionId == 8)) {
                return new MainStatistics_Advanced_TypedDataContext5_ForReadOnly(locationReferences).@__Expr8GetTree();
            }
            if ((expressionId == 9)) {
                return new MainStatistics_Advanced_TypedDataContext5_ForReadOnly(locationReferences).@__Expr9GetTree();
            }
            if ((expressionId == 10)) {
                return new MainStatistics_Advanced_TypedDataContext9_ForReadOnly(locationReferences).@__Expr10GetTree();
            }
            if ((expressionId == 11)) {
                return new MainStatistics_Advanced_TypedDataContext9(locationReferences).@__Expr11GetTree();
            }
            if ((expressionId == 12)) {
                return new MainStatistics_Advanced_TypedDataContext9_ForReadOnly(locationReferences).@__Expr12GetTree();
            }
            if ((expressionId == 13)) {
                return new MainStatistics_Advanced_TypedDataContext9_ForReadOnly(locationReferences).@__Expr13GetTree();
            }
            if ((expressionId == 14)) {
                return new MainStatistics_Advanced_TypedDataContext9(locationReferences).@__Expr14GetTree();
            }
            if ((expressionId == 15)) {
                return new MainStatistics_Advanced_TypedDataContext9(locationReferences).@__Expr15GetTree();
            }
            if ((expressionId == 16)) {
                return new MainStatistics_Advanced_TypedDataContext8_ForReadOnly(locationReferences).@__Expr16GetTree();
            }
            if ((expressionId == 17)) {
                return new MainStatistics_Advanced_TypedDataContext8_ForReadOnly(locationReferences).@__Expr17GetTree();
            }
            if ((expressionId == 18)) {
                return new MainStatistics_Advanced_TypedDataContext10_ForReadOnly(locationReferences).@__Expr18GetTree();
            }
            if ((expressionId == 19)) {
                return new MainStatistics_Advanced_TypedDataContext10_ForReadOnly(locationReferences).@__Expr19GetTree();
            }
            if ((expressionId == 20)) {
                return new MainStatistics_Advanced_TypedDataContext10_ForReadOnly(locationReferences).@__Expr20GetTree();
            }
            if ((expressionId == 21)) {
                return new MainStatistics_Advanced_TypedDataContext10(locationReferences).@__Expr21GetTree();
            }
            if ((expressionId == 22)) {
                return new MainStatistics_Advanced_TypedDataContext10(locationReferences).@__Expr22GetTree();
            }
            if ((expressionId == 23)) {
                return new MainStatistics_Advanced_TypedDataContext10_ForReadOnly(locationReferences).@__Expr23GetTree();
            }
            if ((expressionId == 24)) {
                return new MainStatistics_Advanced_TypedDataContext10_ForReadOnly(locationReferences).@__Expr24GetTree();
            }
            if ((expressionId == 25)) {
                return new MainStatistics_Advanced_TypedDataContext10_ForReadOnly(locationReferences).@__Expr25GetTree();
            }
            if ((expressionId == 26)) {
                return new MainStatistics_Advanced_TypedDataContext10_ForReadOnly(locationReferences).@__Expr26GetTree();
            }
            if ((expressionId == 27)) {
                return new MainStatistics_Advanced_TypedDataContext10_ForReadOnly(locationReferences).@__Expr27GetTree();
            }
            if ((expressionId == 28)) {
                return new MainStatistics_Advanced_TypedDataContext11_ForReadOnly(locationReferences).@__Expr28GetTree();
            }
            if ((expressionId == 29)) {
                return new MainStatistics_Advanced_TypedDataContext11(locationReferences).@__Expr29GetTree();
            }
            if ((expressionId == 30)) {
                return new MainStatistics_Advanced_TypedDataContext11(locationReferences).@__Expr30GetTree();
            }
            if ((expressionId == 31)) {
                return new MainStatistics_Advanced_TypedDataContext11_ForReadOnly(locationReferences).@__Expr31GetTree();
            }
            if ((expressionId == 32)) {
                return new MainStatistics_Advanced_TypedDataContext11(locationReferences).@__Expr32GetTree();
            }
            if ((expressionId == 33)) {
                return new MainStatistics_Advanced_TypedDataContext11(locationReferences).@__Expr33GetTree();
            }
            if ((expressionId == 34)) {
                return new MainStatistics_Advanced_TypedDataContext11_ForReadOnly(locationReferences).@__Expr34GetTree();
            }
            if ((expressionId == 35)) {
                return new MainStatistics_Advanced_TypedDataContext11_ForReadOnly(locationReferences).@__Expr35GetTree();
            }
            if ((expressionId == 36)) {
                return new MainStatistics_Advanced_TypedDataContext11_ForReadOnly(locationReferences).@__Expr36GetTree();
            }
            if ((expressionId == 37)) {
                return new MainStatistics_Advanced_TypedDataContext11_ForReadOnly(locationReferences).@__Expr37GetTree();
            }
            if ((expressionId == 38)) {
                return new MainStatistics_Advanced_TypedDataContext11_ForReadOnly(locationReferences).@__Expr38GetTree();
            }
            if ((expressionId == 39)) {
                return new MainStatistics_Advanced_TypedDataContext11_ForReadOnly(locationReferences).@__Expr39GetTree();
            }
            if ((expressionId == 40)) {
                return new MainStatistics_Advanced_TypedDataContext12_ForReadOnly(locationReferences).@__Expr40GetTree();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class MainStatistics_Advanced_TypedDataContext0 : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public MainStatistics_Advanced_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext0(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            internal static object GetDataContextActivitiesHelper(System.Activities.Activity compiledRoot, bool forImplementation) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetDataContextActivities(compiledRoot, forImplementation);
            }
            
            internal static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
            }
            
            public static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 0))) {
                    return false;
                }
                expectedLocationsCount = 0;
                return true;
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class MainStatistics_Advanced_TypedDataContext0_ForReadOnly : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public MainStatistics_Advanced_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            internal static object GetDataContextActivitiesHelper(System.Activities.Activity compiledRoot, bool forImplementation) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetDataContextActivities(compiledRoot, forImplementation);
            }
            
            internal static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
            }
            
            public static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 0))) {
                    return false;
                }
                expectedLocationsCount = 0;
                return true;
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class MainStatistics_Advanced_TypedDataContext1 : MainStatistics_Advanced_TypedDataContext0 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            protected int Temp_Result;
            
            protected int Temp_State;
            
            public MainStatistics_Advanced_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext1(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string Temp_FirstMsgId {
                get {
                    return ((string)(this.GetVariableValue((0 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((0 + locationsOffset), value);
                }
            }
            
            protected string TempBookMarkName {
                get {
                    return ((string)(this.GetVariableValue((2 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((2 + locationsOffset), value);
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            protected override void GetValueTypeValues() {
                this.Temp_Result = ((int)(this.GetVariableValue((1 + locationsOffset))));
                this.Temp_State = ((int)(this.GetVariableValue((3 + locationsOffset))));
                base.GetValueTypeValues();
            }
            
            protected override void SetValueTypeValues() {
                this.SetVariableValue((1 + locationsOffset), this.Temp_Result);
                this.SetVariableValue((3 + locationsOffset), this.Temp_State);
                base.SetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 4))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 4);
                }
                expectedLocationsCount = 4;
                if (((locationReferences[(offset + 0)].Name != "Temp_FirstMsgId") 
                            || (locationReferences[(offset + 0)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 2)].Name != "TempBookMarkName") 
                            || (locationReferences[(offset + 2)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "Temp_Result") 
                            || (locationReferences[(offset + 1)].Type != typeof(int)))) {
                    return false;
                }
                if (((locationReferences[(offset + 3)].Name != "Temp_State") 
                            || (locationReferences[(offset + 3)].Type != typeof(int)))) {
                    return false;
                }
                return MainStatistics_Advanced_TypedDataContext0.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class MainStatistics_Advanced_TypedDataContext1_ForReadOnly : MainStatistics_Advanced_TypedDataContext0_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            protected int Temp_Result;
            
            protected int Temp_State;
            
            public MainStatistics_Advanced_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string Temp_FirstMsgId {
                get {
                    return ((string)(this.GetVariableValue((0 + locationsOffset))));
                }
            }
            
            protected string TempBookMarkName {
                get {
                    return ((string)(this.GetVariableValue((2 + locationsOffset))));
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            protected override void GetValueTypeValues() {
                this.Temp_Result = ((int)(this.GetVariableValue((1 + locationsOffset))));
                this.Temp_State = ((int)(this.GetVariableValue((3 + locationsOffset))));
                base.GetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 4))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 4);
                }
                expectedLocationsCount = 4;
                if (((locationReferences[(offset + 0)].Name != "Temp_FirstMsgId") 
                            || (locationReferences[(offset + 0)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 2)].Name != "TempBookMarkName") 
                            || (locationReferences[(offset + 2)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "Temp_Result") 
                            || (locationReferences[(offset + 1)].Type != typeof(int)))) {
                    return false;
                }
                if (((locationReferences[(offset + 3)].Name != "Temp_State") 
                            || (locationReferences[(offset + 3)].Type != typeof(int)))) {
                    return false;
                }
                return MainStatistics_Advanced_TypedDataContext0_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class MainStatistics_Advanced_TypedDataContext2 : MainStatistics_Advanced_TypedDataContext1 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            protected int _sleepTime;
            
            protected double _secs_interval;
            
            protected int _state;
            
            protected int _result;
            
            public MainStatistics_Advanced_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext2(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string _id_list {
                get {
                    return ((string)(this.GetVariableValue((5 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((5 + locationsOffset), value);
                }
            }
            
            protected System.Collections.Generic.List<PMS.Model.QueryModel.Redis_SMSContent> _list_redis {
                get {
                    return ((System.Collections.Generic.List<PMS.Model.QueryModel.Redis_SMSContent>)(this.GetVariableValue((7 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((7 + locationsOffset), value);
                }
            }
            
            protected PMS.Model.QueryModel.Redis_SMSContent _query_obj {
                get {
                    return ((PMS.Model.QueryModel.Redis_SMSContent)(this.GetVariableValue((8 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((8 + locationsOffset), value);
                }
            }
            
            protected System.Collections.Generic.List<PMS.Model.SMSModel.SMSModel_QueryReceive> _list_queryReceive {
                get {
                    return ((System.Collections.Generic.List<PMS.Model.SMSModel.SMSModel_QueryReceive>)(this.GetVariableValue((9 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((9 + locationsOffset), value);
                }
            }
            
            protected string _first_msgid {
                get {
                    return ((string)(this.GetVariableValue((11 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((11 + locationsOffset), value);
                }
            }
            
            protected string _id_list_msgid {
                get {
                    return ((string)(this.GetVariableValue((13 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((13 + locationsOffset), value);
                }
            }
            
            protected string _id_hash {
                get {
                    return ((string)(this.GetVariableValue((14 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((14 + locationsOffset), value);
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            protected override void GetValueTypeValues() {
                this._sleepTime = ((int)(this.GetVariableValue((4 + locationsOffset))));
                this._secs_interval = ((double)(this.GetVariableValue((6 + locationsOffset))));
                this._state = ((int)(this.GetVariableValue((10 + locationsOffset))));
                this._result = ((int)(this.GetVariableValue((12 + locationsOffset))));
                base.GetValueTypeValues();
            }
            
            protected override void SetValueTypeValues() {
                this.SetVariableValue((4 + locationsOffset), this._sleepTime);
                this.SetVariableValue((6 + locationsOffset), this._secs_interval);
                this.SetVariableValue((10 + locationsOffset), this._state);
                this.SetVariableValue((12 + locationsOffset), this._result);
                base.SetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 15))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 15);
                }
                expectedLocationsCount = 15;
                if (((locationReferences[(offset + 5)].Name != "_id_list") 
                            || (locationReferences[(offset + 5)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 7)].Name != "_list_redis") 
                            || (locationReferences[(offset + 7)].Type != typeof(System.Collections.Generic.List<PMS.Model.QueryModel.Redis_SMSContent>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 8)].Name != "_query_obj") 
                            || (locationReferences[(offset + 8)].Type != typeof(PMS.Model.QueryModel.Redis_SMSContent)))) {
                    return false;
                }
                if (((locationReferences[(offset + 9)].Name != "_list_queryReceive") 
                            || (locationReferences[(offset + 9)].Type != typeof(System.Collections.Generic.List<PMS.Model.SMSModel.SMSModel_QueryReceive>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 11)].Name != "_first_msgid") 
                            || (locationReferences[(offset + 11)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 13)].Name != "_id_list_msgid") 
                            || (locationReferences[(offset + 13)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 14)].Name != "_id_hash") 
                            || (locationReferences[(offset + 14)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 4)].Name != "_sleepTime") 
                            || (locationReferences[(offset + 4)].Type != typeof(int)))) {
                    return false;
                }
                if (((locationReferences[(offset + 6)].Name != "_secs_interval") 
                            || (locationReferences[(offset + 6)].Type != typeof(double)))) {
                    return false;
                }
                if (((locationReferences[(offset + 10)].Name != "_state") 
                            || (locationReferences[(offset + 10)].Type != typeof(int)))) {
                    return false;
                }
                if (((locationReferences[(offset + 12)].Name != "_result") 
                            || (locationReferences[(offset + 12)].Type != typeof(int)))) {
                    return false;
                }
                return MainStatistics_Advanced_TypedDataContext1.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class MainStatistics_Advanced_TypedDataContext2_ForReadOnly : MainStatistics_Advanced_TypedDataContext1_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            protected int _sleepTime;
            
            protected double _secs_interval;
            
            protected int _state;
            
            protected int _result;
            
            public MainStatistics_Advanced_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string _id_list {
                get {
                    return ((string)(this.GetVariableValue((5 + locationsOffset))));
                }
            }
            
            protected System.Collections.Generic.List<PMS.Model.QueryModel.Redis_SMSContent> _list_redis {
                get {
                    return ((System.Collections.Generic.List<PMS.Model.QueryModel.Redis_SMSContent>)(this.GetVariableValue((7 + locationsOffset))));
                }
            }
            
            protected PMS.Model.QueryModel.Redis_SMSContent _query_obj {
                get {
                    return ((PMS.Model.QueryModel.Redis_SMSContent)(this.GetVariableValue((8 + locationsOffset))));
                }
            }
            
            protected System.Collections.Generic.List<PMS.Model.SMSModel.SMSModel_QueryReceive> _list_queryReceive {
                get {
                    return ((System.Collections.Generic.List<PMS.Model.SMSModel.SMSModel_QueryReceive>)(this.GetVariableValue((9 + locationsOffset))));
                }
            }
            
            protected string _first_msgid {
                get {
                    return ((string)(this.GetVariableValue((11 + locationsOffset))));
                }
            }
            
            protected string _id_list_msgid {
                get {
                    return ((string)(this.GetVariableValue((13 + locationsOffset))));
                }
            }
            
            protected string _id_hash {
                get {
                    return ((string)(this.GetVariableValue((14 + locationsOffset))));
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            protected override void GetValueTypeValues() {
                this._sleepTime = ((int)(this.GetVariableValue((4 + locationsOffset))));
                this._secs_interval = ((double)(this.GetVariableValue((6 + locationsOffset))));
                this._state = ((int)(this.GetVariableValue((10 + locationsOffset))));
                this._result = ((int)(this.GetVariableValue((12 + locationsOffset))));
                base.GetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 15))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 15);
                }
                expectedLocationsCount = 15;
                if (((locationReferences[(offset + 5)].Name != "_id_list") 
                            || (locationReferences[(offset + 5)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 7)].Name != "_list_redis") 
                            || (locationReferences[(offset + 7)].Type != typeof(System.Collections.Generic.List<PMS.Model.QueryModel.Redis_SMSContent>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 8)].Name != "_query_obj") 
                            || (locationReferences[(offset + 8)].Type != typeof(PMS.Model.QueryModel.Redis_SMSContent)))) {
                    return false;
                }
                if (((locationReferences[(offset + 9)].Name != "_list_queryReceive") 
                            || (locationReferences[(offset + 9)].Type != typeof(System.Collections.Generic.List<PMS.Model.SMSModel.SMSModel_QueryReceive>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 11)].Name != "_first_msgid") 
                            || (locationReferences[(offset + 11)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 13)].Name != "_id_list_msgid") 
                            || (locationReferences[(offset + 13)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 14)].Name != "_id_hash") 
                            || (locationReferences[(offset + 14)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 4)].Name != "_sleepTime") 
                            || (locationReferences[(offset + 4)].Type != typeof(int)))) {
                    return false;
                }
                if (((locationReferences[(offset + 6)].Name != "_secs_interval") 
                            || (locationReferences[(offset + 6)].Type != typeof(double)))) {
                    return false;
                }
                if (((locationReferences[(offset + 10)].Name != "_state") 
                            || (locationReferences[(offset + 10)].Type != typeof(int)))) {
                    return false;
                }
                if (((locationReferences[(offset + 12)].Name != "_result") 
                            || (locationReferences[(offset + 12)].Type != typeof(int)))) {
                    return false;
                }
                return MainStatistics_Advanced_TypedDataContext1_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class MainStatistics_Advanced_TypedDataContext3 : MainStatistics_Advanced_TypedDataContext2 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public MainStatistics_Advanced_TypedDataContext3(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext3(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext3(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr0GetTree() {
                
                #line 70 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                    _id_hash;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr0Get() {
                
                #line 70 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                    _id_hash;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr0Get() {
                this.GetValueTypeValues();
                return this.@__Expr0Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr0Set(string value) {
                
                #line 70 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                
                    _id_hash = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr0Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr0Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr1GetTree() {
                
                #line 80 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                    _id_list_msgid;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr1Get() {
                
                #line 80 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                    _id_list_msgid;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr1Get() {
                this.GetValueTypeValues();
                return this.@__Expr1Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr1Set(string value) {
                
                #line 80 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                
                    _id_list_msgid = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr1Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr1Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr2GetTree() {
                
                #line 90 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<int>> expression = () => 
                    _sleepTime;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public int @__Expr2Get() {
                
                #line 90 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                    _sleepTime;
                
                #line default
                #line hidden
            }
            
            public int ValueType___Expr2Get() {
                this.GetValueTypeValues();
                return this.@__Expr2Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr2Set(int value) {
                
                #line 90 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                
                    _sleepTime = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr2Set(int value) {
                this.GetValueTypeValues();
                this.@__Expr2Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr3GetTree() {
                
                #line 75 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                    _id_list;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr3Get() {
                
                #line 75 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                    _id_list;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr3Get() {
                this.GetValueTypeValues();
                return this.@__Expr3Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr3Set(string value) {
                
                #line 75 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                
                    _id_list = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr3Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr3Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr4GetTree() {
                
                #line 85 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<double>> expression = () => 
                    _secs_interval;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public double @__Expr4Get() {
                
                #line 85 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                    _secs_interval;
                
                #line default
                #line hidden
            }
            
            public double ValueType___Expr4Get() {
                this.GetValueTypeValues();
                return this.@__Expr4Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr4Set(double value) {
                
                #line 85 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                
                    _secs_interval = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr4Set(double value) {
                this.GetValueTypeValues();
                this.@__Expr4Set(value);
                this.SetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 15))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 15);
                }
                expectedLocationsCount = 15;
                return MainStatistics_Advanced_TypedDataContext2.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class MainStatistics_Advanced_TypedDataContext3_ForReadOnly : MainStatistics_Advanced_TypedDataContext2_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public MainStatistics_Advanced_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 15))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 15);
                }
                expectedLocationsCount = 15;
                return MainStatistics_Advanced_TypedDataContext2_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class MainStatistics_Advanced_TypedDataContext4 : MainStatistics_Advanced_TypedDataContext2 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public MainStatistics_Advanced_TypedDataContext4(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext4(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext4(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 15))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 15);
                }
                expectedLocationsCount = 15;
                return MainStatistics_Advanced_TypedDataContext2.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class MainStatistics_Advanced_TypedDataContext4_ForReadOnly : MainStatistics_Advanced_TypedDataContext2_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public MainStatistics_Advanced_TypedDataContext4_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext4_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext4_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 15))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 15);
                }
                expectedLocationsCount = 15;
                return MainStatistics_Advanced_TypedDataContext2_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class MainStatistics_Advanced_TypedDataContext5 : MainStatistics_Advanced_TypedDataContext2 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public MainStatistics_Advanced_TypedDataContext5(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext5(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext5(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 15))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 15);
                }
                expectedLocationsCount = 15;
                return MainStatistics_Advanced_TypedDataContext2.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class MainStatistics_Advanced_TypedDataContext5_ForReadOnly : MainStatistics_Advanced_TypedDataContext2_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public MainStatistics_Advanced_TypedDataContext5_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext5_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext5_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr8GetTree() {
                
                #line 133 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                      _list_redis.Count>0;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr8Get() {
                
                #line 133 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                      _list_redis.Count>0;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr8Get() {
                this.GetValueTypeValues();
                return this.@__Expr8Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr9GetTree() {
                
                #line 398 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                      _list_redis.Count==0;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr9Get() {
                
                #line 398 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                      _list_redis.Count==0;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr9Get() {
                this.GetValueTypeValues();
                return this.@__Expr9Get();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 15))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 15);
                }
                expectedLocationsCount = 15;
                return MainStatistics_Advanced_TypedDataContext2_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class MainStatistics_Advanced_TypedDataContext6 : MainStatistics_Advanced_TypedDataContext5 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public MainStatistics_Advanced_TypedDataContext6(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext6(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext6(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string variable1 {
                get {
                    return ((string)(this.GetVariableValue((15 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((15 + locationsOffset), value);
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr5GetTree() {
                
                #line 117 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<PMS.Model.QueryModel.Redis_SMSContent>>> expression = () => 
                            _list_redis;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<PMS.Model.QueryModel.Redis_SMSContent> @__Expr5Get() {
                
                #line 117 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                            _list_redis;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<PMS.Model.QueryModel.Redis_SMSContent> ValueType___Expr5Get() {
                this.GetValueTypeValues();
                return this.@__Expr5Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr5Set(System.Collections.Generic.List<PMS.Model.QueryModel.Redis_SMSContent> value) {
                
                #line 117 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                
                            _list_redis = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr5Set(System.Collections.Generic.List<PMS.Model.QueryModel.Redis_SMSContent> value) {
                this.GetValueTypeValues();
                this.@__Expr5Set(value);
                this.SetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 16))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 16);
                }
                expectedLocationsCount = 16;
                if (((locationReferences[(offset + 15)].Name != "variable1") 
                            || (locationReferences[(offset + 15)].Type != typeof(string)))) {
                    return false;
                }
                return MainStatistics_Advanced_TypedDataContext5.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class MainStatistics_Advanced_TypedDataContext6_ForReadOnly : MainStatistics_Advanced_TypedDataContext5_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public MainStatistics_Advanced_TypedDataContext6_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext6_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext6_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string variable1 {
                get {
                    return ((string)(this.GetVariableValue((15 + locationsOffset))));
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr6GetTree() {
                
                #line 122 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<double>> expression = () => 
                            _secs_interval;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public double @__Expr6Get() {
                
                #line 122 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                            _secs_interval;
                
                #line default
                #line hidden
            }
            
            public double ValueType___Expr6Get() {
                this.GetValueTypeValues();
                return this.@__Expr6Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr7GetTree() {
                
                #line 112 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                            _id_list;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr7Get() {
                
                #line 112 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                            _id_list;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr7Get() {
                this.GetValueTypeValues();
                return this.@__Expr7Get();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 16))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 16);
                }
                expectedLocationsCount = 16;
                if (((locationReferences[(offset + 15)].Name != "variable1") 
                            || (locationReferences[(offset + 15)].Type != typeof(string)))) {
                    return false;
                }
                return MainStatistics_Advanced_TypedDataContext5_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class MainStatistics_Advanced_TypedDataContext7 : MainStatistics_Advanced_TypedDataContext2 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public MainStatistics_Advanced_TypedDataContext7(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext7(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext7(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 15))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 15);
                }
                expectedLocationsCount = 15;
                return MainStatistics_Advanced_TypedDataContext2.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class MainStatistics_Advanced_TypedDataContext7_ForReadOnly : MainStatistics_Advanced_TypedDataContext2_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public MainStatistics_Advanced_TypedDataContext7_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext7_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext7_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 15))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 15);
                }
                expectedLocationsCount = 15;
                return MainStatistics_Advanced_TypedDataContext2_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class MainStatistics_Advanced_TypedDataContext8 : MainStatistics_Advanced_TypedDataContext7 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public MainStatistics_Advanced_TypedDataContext8(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext8(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext8(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected System.Collections.Generic.List<PMS.Model.QueryModel.Redis_SMSContent> list_redis {
                get {
                    return ((System.Collections.Generic.List<PMS.Model.QueryModel.Redis_SMSContent>)(this.GetVariableValue((15 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((15 + locationsOffset), value);
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 16))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 16);
                }
                expectedLocationsCount = 16;
                if (((locationReferences[(offset + 15)].Name != "list_redis") 
                            || (locationReferences[(offset + 15)].Type != typeof(System.Collections.Generic.List<PMS.Model.QueryModel.Redis_SMSContent>)))) {
                    return false;
                }
                return MainStatistics_Advanced_TypedDataContext7.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class MainStatistics_Advanced_TypedDataContext8_ForReadOnly : MainStatistics_Advanced_TypedDataContext7_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public MainStatistics_Advanced_TypedDataContext8_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext8_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext8_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected System.Collections.Generic.List<PMS.Model.QueryModel.Redis_SMSContent> list_redis {
                get {
                    return ((System.Collections.Generic.List<PMS.Model.QueryModel.Redis_SMSContent>)(this.GetVariableValue((15 + locationsOffset))));
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr16GetTree() {
                
                #line 378 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                              _query_obj.msgid != string.Empty&&_result==1;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr16Get() {
                
                #line 378 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                              _query_obj.msgid != string.Empty&&_result==1;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr16Get() {
                this.GetValueTypeValues();
                return this.@__Expr16Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr17GetTree() {
                
                #line 383 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                              _result==3;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr17Get() {
                
                #line 383 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                              _result==3;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr17Get() {
                this.GetValueTypeValues();
                return this.@__Expr17Get();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 16))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 16);
                }
                expectedLocationsCount = 16;
                if (((locationReferences[(offset + 15)].Name != "list_redis") 
                            || (locationReferences[(offset + 15)].Type != typeof(System.Collections.Generic.List<PMS.Model.QueryModel.Redis_SMSContent>)))) {
                    return false;
                }
                return MainStatistics_Advanced_TypedDataContext7_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class MainStatistics_Advanced_TypedDataContext9 : MainStatistics_Advanced_TypedDataContext8 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public MainStatistics_Advanced_TypedDataContext9(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext9(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext9(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected PMS.Model.QueryModel.Redis_SMSContent _first_obj {
                get {
                    return ((PMS.Model.QueryModel.Redis_SMSContent)(this.GetVariableValue((16 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((16 + locationsOffset), value);
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr11GetTree() {
                
                #line 173 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<int>> expression = () => 
                                    _result;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public int @__Expr11Get() {
                
                #line 173 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                                    _result;
                
                #line default
                #line hidden
            }
            
            public int ValueType___Expr11Get() {
                this.GetValueTypeValues();
                return this.@__Expr11Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr11Set(int value) {
                
                #line 173 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                
                                    _result = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr11Set(int value) {
                this.GetValueTypeValues();
                this.@__Expr11Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr14GetTree() {
                
                #line 163 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                    _first_msgid;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr14Get() {
                
                #line 163 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                                    _first_msgid;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr14Get() {
                this.GetValueTypeValues();
                return this.@__Expr14Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr14Set(string value) {
                
                #line 163 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                
                                    _first_msgid = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr14Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr14Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr15GetTree() {
                
                #line 148 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<PMS.Model.QueryModel.Redis_SMSContent>> expression = () => 
                                    _query_obj;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public PMS.Model.QueryModel.Redis_SMSContent @__Expr15Get() {
                
                #line 148 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                                    _query_obj;
                
                #line default
                #line hidden
            }
            
            public PMS.Model.QueryModel.Redis_SMSContent ValueType___Expr15Get() {
                this.GetValueTypeValues();
                return this.@__Expr15Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr15Set(PMS.Model.QueryModel.Redis_SMSContent value) {
                
                #line 148 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                
                                    _query_obj = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr15Set(PMS.Model.QueryModel.Redis_SMSContent value) {
                this.GetValueTypeValues();
                this.@__Expr15Set(value);
                this.SetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 17))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 17);
                }
                expectedLocationsCount = 17;
                if (((locationReferences[(offset + 16)].Name != "_first_obj") 
                            || (locationReferences[(offset + 16)].Type != typeof(PMS.Model.QueryModel.Redis_SMSContent)))) {
                    return false;
                }
                return MainStatistics_Advanced_TypedDataContext8.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class MainStatistics_Advanced_TypedDataContext9_ForReadOnly : MainStatistics_Advanced_TypedDataContext8_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public MainStatistics_Advanced_TypedDataContext9_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext9_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext9_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected PMS.Model.QueryModel.Redis_SMSContent _first_obj {
                get {
                    return ((PMS.Model.QueryModel.Redis_SMSContent)(this.GetVariableValue((16 + locationsOffset))));
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr10GetTree() {
                
                #line 158 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<PMS.Model.QueryModel.Redis_SMSContent>>> expression = () => 
                                    _list_redis;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<PMS.Model.QueryModel.Redis_SMSContent> @__Expr10Get() {
                
                #line 158 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                                    _list_redis;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<PMS.Model.QueryModel.Redis_SMSContent> ValueType___Expr10Get() {
                this.GetValueTypeValues();
                return this.@__Expr10Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr12GetTree() {
                
                #line 168 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<double>> expression = () => 
                                    _secs_interval;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public double @__Expr12Get() {
                
                #line 168 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                                    _secs_interval;
                
                #line default
                #line hidden
            }
            
            public double ValueType___Expr12Get() {
                this.GetValueTypeValues();
                return this.@__Expr12Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr13GetTree() {
                
                #line 153 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                    _id_list;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr13Get() {
                
                #line 153 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                                    _id_list;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr13Get() {
                this.GetValueTypeValues();
                return this.@__Expr13Get();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 17))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 17);
                }
                expectedLocationsCount = 17;
                if (((locationReferences[(offset + 16)].Name != "_first_obj") 
                            || (locationReferences[(offset + 16)].Type != typeof(PMS.Model.QueryModel.Redis_SMSContent)))) {
                    return false;
                }
                return MainStatistics_Advanced_TypedDataContext8_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class MainStatistics_Advanced_TypedDataContext10 : MainStatistics_Advanced_TypedDataContext2 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public MainStatistics_Advanced_TypedDataContext10(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext10(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext10(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr21GetTree() {
                
                #line 204 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<PMS.Model.SMSModel.SMSModel_QueryReceive>>> expression = () => 
                                                  _list_queryReceive;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<PMS.Model.SMSModel.SMSModel_QueryReceive> @__Expr21Get() {
                
                #line 204 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                                                  _list_queryReceive;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<PMS.Model.SMSModel.SMSModel_QueryReceive> ValueType___Expr21Get() {
                this.GetValueTypeValues();
                return this.@__Expr21Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr21Set(System.Collections.Generic.List<PMS.Model.SMSModel.SMSModel_QueryReceive> value) {
                
                #line 204 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                
                                                  _list_queryReceive = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr21Set(System.Collections.Generic.List<PMS.Model.SMSModel.SMSModel_QueryReceive> value) {
                this.GetValueTypeValues();
                this.@__Expr21Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr22GetTree() {
                
                #line 219 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<int>> expression = () => 
                                                  _state;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public int @__Expr22Get() {
                
                #line 219 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                                                  _state;
                
                #line default
                #line hidden
            }
            
            public int ValueType___Expr22Get() {
                this.GetValueTypeValues();
                return this.@__Expr22Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr22Set(int value) {
                
                #line 219 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                
                                                  _state = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr22Set(int value) {
                this.GetValueTypeValues();
                this.@__Expr22Set(value);
                this.SetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 15))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 15);
                }
                expectedLocationsCount = 15;
                return MainStatistics_Advanced_TypedDataContext2.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class MainStatistics_Advanced_TypedDataContext10_ForReadOnly : MainStatistics_Advanced_TypedDataContext2_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public MainStatistics_Advanced_TypedDataContext10_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext10_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext10_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr18GetTree() {
                
                #line 195 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                        _state==0;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr18Get() {
                
                #line 195 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                                        _state==0;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr18Get() {
                this.GetValueTypeValues();
                return this.@__Expr18Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr19GetTree() {
                
                #line 214 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<PMS.Model.QueryModel.Redis_SMSContent>> expression = () => 
                                                  _query_obj;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public PMS.Model.QueryModel.Redis_SMSContent @__Expr19Get() {
                
                #line 214 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                                                  _query_obj;
                
                #line default
                #line hidden
            }
            
            public PMS.Model.QueryModel.Redis_SMSContent ValueType___Expr19Get() {
                this.GetValueTypeValues();
                return this.@__Expr19Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr20GetTree() {
                
                #line 209 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                  _first_msgid;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr20Get() {
                
                #line 209 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                                                  _first_msgid;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr20Get() {
                this.GetValueTypeValues();
                return this.@__Expr20Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr23GetTree() {
                
                #line 227 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<int>> expression = () => 
                                                  _sleepTime;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public int @__Expr23Get() {
                
                #line 227 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                                                  _sleepTime;
                
                #line default
                #line hidden
            }
            
            public int ValueType___Expr23Get() {
                this.GetValueTypeValues();
                return this.@__Expr23Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr24GetTree() {
                
                #line 235 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                            "此时状态码为"+_state;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr24Get() {
                
                #line 235 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                                            "此时状态码为"+_state;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr24Get() {
                this.GetValueTypeValues();
                return this.@__Expr24Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr25GetTree() {
                
                #line 340 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                      (_state==1||_state==2)&&_result!=4;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr25Get() {
                
                #line 340 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                                      (_state==1||_state==2)&&_result!=4;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr25Get() {
                this.GetValueTypeValues();
                return this.@__Expr25Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr26GetTree() {
                
                #line 368 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                      _result==4;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr26Get() {
                
                #line 368 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                                      _result==4;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr26Get() {
                this.GetValueTypeValues();
                return this.@__Expr26Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr27GetTree() {
                
                #line 363 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                          "状态码为"+_result+"工作流被挂起";
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr27Get() {
                
                #line 363 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                                          "状态码为"+_result+"工作流被挂起";
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr27Get() {
                this.GetValueTypeValues();
                return this.@__Expr27Get();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 15))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 15);
                }
                expectedLocationsCount = 15;
                return MainStatistics_Advanced_TypedDataContext2_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class MainStatistics_Advanced_TypedDataContext11 : MainStatistics_Advanced_TypedDataContext2 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public MainStatistics_Advanced_TypedDataContext11(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext11(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext11(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr29GetTree() {
                
                #line 281 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<int>> expression = () => 
                                                  _result;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public int @__Expr29Get() {
                
                #line 281 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                                                  _result;
                
                #line default
                #line hidden
            }
            
            public int ValueType___Expr29Get() {
                this.GetValueTypeValues();
                return this.@__Expr29Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr29Set(int value) {
                
                #line 281 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                
                                                  _result = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr29Set(int value) {
                this.GetValueTypeValues();
                this.@__Expr29Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr30GetTree() {
                
                #line 256 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                  TempBookMarkName;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr30Get() {
                
                #line 256 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                                                  TempBookMarkName;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr30Get() {
                this.GetValueTypeValues();
                return this.@__Expr30Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr30Set(string value) {
                
                #line 256 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                
                                                  TempBookMarkName = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr30Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr30Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr32GetTree() {
                
                #line 271 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                  _first_msgid;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr32Get() {
                
                #line 271 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                                                  _first_msgid;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr32Get() {
                this.GetValueTypeValues();
                return this.@__Expr32Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr32Set(string value) {
                
                #line 271 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                
                                                  _first_msgid = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr32Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr32Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr33GetTree() {
                
                #line 276 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<int>> expression = () => 
                                                  _state;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public int @__Expr33Get() {
                
                #line 276 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                                                  _state;
                
                #line default
                #line hidden
            }
            
            public int ValueType___Expr33Get() {
                this.GetValueTypeValues();
                return this.@__Expr33Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr33Set(int value) {
                
                #line 276 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                
                                                  _state = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr33Set(int value) {
                this.GetValueTypeValues();
                this.@__Expr33Set(value);
                this.SetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 15))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 15);
                }
                expectedLocationsCount = 15;
                return MainStatistics_Advanced_TypedDataContext2.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class MainStatistics_Advanced_TypedDataContext11_ForReadOnly : MainStatistics_Advanced_TypedDataContext2_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public MainStatistics_Advanced_TypedDataContext11_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext11_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext11_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr28GetTree() {
                
                #line 261 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                  _id_hash;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr28Get() {
                
                #line 261 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                                                  _id_hash;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr28Get() {
                this.GetValueTypeValues();
                return this.@__Expr28Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr31GetTree() {
                
                #line 266 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                  _id_list_msgid;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr31Get() {
                
                #line 266 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                                                  _id_list_msgid;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr31Get() {
                this.GetValueTypeValues();
                return this.@__Expr31Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr34GetTree() {
                
                #line 287 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                "书签中的state为"+_state;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr34Get() {
                
                #line 287 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                                                "书签中的state为"+_state;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr34Get() {
                this.GetValueTypeValues();
                return this.@__Expr34Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr35GetTree() {
                
                #line 292 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                "书签中的result为"+_result;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr35Get() {
                
                #line 292 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                                                "书签中的result为"+_result;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr35Get() {
                this.GetValueTypeValues();
                return this.@__Expr35Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr36GetTree() {
                
                #line 297 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                "该书签恢复的MsgId为"+_first_msgid;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr36Get() {
                
                #line 297 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                                                "该书签恢复的MsgId为"+_first_msgid;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr36Get() {
                this.GetValueTypeValues();
                return this.@__Expr36Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr37GetTree() {
                
                #line 308 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                              _result==4;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr37Get() {
                
                #line 308 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                                              _result==4;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr37Get() {
                this.GetValueTypeValues();
                return this.@__Expr37Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr38GetTree() {
                
                #line 330 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                              _result==6;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr38Get() {
                
                #line 330 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                                              _result==6;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr38Get() {
                this.GetValueTypeValues();
                return this.@__Expr38Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr39GetTree() {
                
                #line 325 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                  "resut为"+_result;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr39Get() {
                
                #line 325 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                                                  "resut为"+_result;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr39Get() {
                this.GetValueTypeValues();
                return this.@__Expr39Get();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 15))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 15);
                }
                expectedLocationsCount = 15;
                return MainStatistics_Advanced_TypedDataContext2_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class MainStatistics_Advanced_TypedDataContext12 : MainStatistics_Advanced_TypedDataContext2 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public MainStatistics_Advanced_TypedDataContext12(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext12(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext12(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 15))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 15);
                }
                expectedLocationsCount = 15;
                return MainStatistics_Advanced_TypedDataContext2.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class MainStatistics_Advanced_TypedDataContext12_ForReadOnly : MainStatistics_Advanced_TypedDataContext2_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public MainStatistics_Advanced_TypedDataContext12_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext12_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MainStatistics_Advanced_TypedDataContext12_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr40GetTree() {
                
                #line 354 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                              _result==6;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr40Get() {
                
                #line 354 "E:\03协同开发\短信\PMS\PMS\WFTEST\MAINSTATISTICS_ADVANCED.XAML"
                return 
                                              _result==6;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr40Get() {
                this.GetValueTypeValues();
                return this.@__Expr40Get();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 15))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 15);
                }
                expectedLocationsCount = 15;
                return MainStatistics_Advanced_TypedDataContext2_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
    }
}
