using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfGoClient
{
    class NetworkNode
    {
        public static int TYPE_INPUT = 0;
        public static int TYPE_HIDDEN = 1;
        public static int TYPE_OUTPUT = 2;

        private int type;
        public void setType(int type)
        {
            this.type = type;
        }

        // 节点前向输入输出值
        private double mForwardInputValue;
        private double mForwardOutputValue;

        // 节点反向输入输出值
        private double mBackwardInputValue;
        private double mBackwardOutputValue;

        public NetworkNode()
        {
        }

        public NetworkNode(int type)
        {
            this.type = type;
        }

        /**
         * sigmoid函数，这里用tan-sigmoid，经测试其效果比log-sigmoid好！
         * 
         * @param in
         * @return
         */
        private double forwardSigmoid(double input)
        {
            switch (type)
            {
                case 0: //TYPE_INPUT
                    return input;
                    
                case 1: //TYPE_HIDDEN
                case 2: //TYPE_OUTPUT
                    return tanhS(input);
            }
            return 0;
        }

        /**
    * log-sigmoid函数
    * 
    * @param in
    * @return
    */
        private double logS(double input)
        {
            return (double)(1 / (1 + Math.Exp(-input)));
        }

        /**
         * log-sigmoid函数的导数
         * 
         * @param in
         * @return
         */
        private double logSDerivative(double input)
        {
            return mForwardOutputValue * (1 - mForwardOutputValue) * input;
        }

        /**
         * tan-sigmoid函数
         * 
         * @param in
         * @return
         */
        private double tanhS(double input)
        {
            return (double)((Math.Exp(input) - Math.Exp(-input)) / (Math.Exp(input) + Math
                    .Exp(-input)));
        }

        /**
         * tan-sigmoid函数的导数
         * 
         * @param in
         * @return
         */
        private double tanhSDerivative(double input)
        {
            return (double)((1 - Math.Pow(mForwardOutputValue, 2)) * input);
        }

        /**
     * 误差反向传播时，激活函数的导数
     * 
     * @param in
     * @return
     */
        private double backwardPropagate(double input)
        {
            switch (type)
            {
                case 0:
                    return input;
                case 1:
                case 2:
                    return tanhSDerivative(input);
            }
            return 0;
        }

        public double getForwardInputValue()
        {
            return mForwardInputValue;
        }

        public void setForwardInputValue(double mInputValue)
        {
            this.mForwardInputValue = mInputValue;
            setForwardOutputValue(mInputValue);
        }

        public double getForwardOutputValue()
        {
            return mForwardOutputValue;
        }

        private void setForwardOutputValue(double mInputValue)
        {
            this.mForwardOutputValue = forwardSigmoid(mInputValue);
        }

        public double getBackwardInputValue()
        {
            return mBackwardInputValue;
        }

        public void setBackwardInputValue(double mBackwardInputValue)
        {
            this.mBackwardInputValue = mBackwardInputValue;
            setBackwardOutputValue(mBackwardInputValue);
        }

        public double getBackwardOutputValue()
        {
            return mBackwardOutputValue;
        }

        private void setBackwardOutputValue(double input)
        {
            this.mBackwardOutputValue = backwardPropagate(input);
        }


    }
}
