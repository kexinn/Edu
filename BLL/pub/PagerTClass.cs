using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.pub
{
    public class PagerTClass
    {
        private int _PageCount;
        private int _RecordCount;
        private int _IndexPage;
        private int _PageSize;
        private bool _FirstShow;
        private bool _PrevShow;
        private bool _NextShow;
        private bool _LastShow;

        public PagerTClass()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 页数
        /// </summary>
        public int PageCount
        {
            get { return _PageCount; }
        }
        /// <summary>
        /// 记录条数
        /// </summary>
        public int RecordCount
        {
            get { return _RecordCount; }
        }
        /// <summary>
        /// 每页显示记录
        /// </summary>
        public int PageSize
        {
            get { return _PageSize; }
        }
        /// <summary>
        /// 当前页
        /// </summary>
        public int IndexPage
        {
            get { return _IndexPage; }
        }
        /// <summary>
        /// 首页
        /// </summary>
        public bool FirstShow
        {
            get { return _FirstShow; }
        }
        /// <summary>
        /// 上一页
        /// </summary>
        public bool PrevShow
        {
            get { return _PrevShow; }
        }
        /// <summary>
        /// 下一页
        /// </summary>
        public bool NextShow
        {
            get { return _NextShow; }
        }
        /// <summary>
        /// 末页
        /// </summary>
        public bool LastShow
        {
            get { return _LastShow; }
        }


        /// <summary>
        /// 分页方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="DataSource"></param>
        /// <param name="indexPg"></param>
        /// <param name="pgSize"></param>
        /// <returns></returns>
        public IEnumerable<T> ShowPage<T>(IEnumerable<T> DataSource, int indexPg, int pgSize)
        {

            _RecordCount = DataSource.Count();
            _IndexPage = indexPg;
            _PageSize = pgSize;
            var rDataSource = DataSource;
            int cTemp = _RecordCount % PageSize;
            _PageCount = (cTemp == 0) ? (_RecordCount / _PageSize) : (_RecordCount / _PageSize + 1);//总页数 
            if (_PageCount == 1) //总共一页数据 
            {
                _FirstShow = false;
                _PrevShow = false;
                _NextShow = false;
                _LastShow = false;
            }
            else
            {
                if (_IndexPage == 1)//首页 
                {
                    rDataSource = DataSource.Take(_PageSize);
                    _FirstShow = false;
                    _PrevShow = false;
                    _NextShow = true;
                    _LastShow = true;
                }
                else
                {
                    rDataSource = DataSource.Skip((_IndexPage - 1) * _PageSize).Take(_PageSize);
                    if (_IndexPage == _PageCount)//末页 
                    {
                        _FirstShow = true;
                        _PrevShow = true;
                        _NextShow = false;
                        _LastShow = false;
                    }
                    else
                    {
                        _FirstShow = true;
                        _PrevShow = true;
                        _NextShow = true;
                        _LastShow = true;
                    }
                }
            }
            return rDataSource;
        }            


    }
}
