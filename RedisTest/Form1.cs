using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using StackExchange.Redis;

namespace RedisTest
{
    public partial class Form1 : Form
    {
        string REDIS_KEY_PREFIX;        
        IDatabase redis_db;
        TimeSpan tsExpire;       

        private void InitComponents()
        {
            REDIS_KEY_PREFIX = ConfigurationManager.AppSettings["RedisKeyPrefix"];            
            int redisKeyDaysExpire = int.Parse(ConfigurationManager.AppSettings["RedisKeyDaysExpire"]);
            tsExpire = TimeSpan.FromDays(redisKeyDaysExpire);

            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(ConfigurationManager.AppSettings["RedisConnectionString"]);
            redis_db = redis.GetDatabase();
        }
        public Form1()
        {
            InitializeComponent();
            InitComponents();
        }

        private void btnCleanFields_Click(object sender, EventArgs e)
        {
            CleanFields();
        }

        private void CleanFields()
        {
            txtKey.Text = String.Empty;
            txtValue.Text = String.Empty;
        }

        private void btnSetKey_Click(object sender, EventArgs e)
        {
            string key = txtKey.Text;
            string value = txtValue.Text;

            string errorMessage = null;
            bool isValid = IsValid(key, out errorMessage);
            if (!isValid)
            {
                MessageBox.Show(errorMessage);
                return;
            }

            //redis_db.StringSet(REDIS_KEY_PREFIX + key, value);
            //redis_db.KeyExpire(REDIS_KEY_PREFIX + key, tsExpire);
            string redisKey = GetRedisKey(REDIS_KEY_PREFIX, key);
            bool redisResult = redis_db.StringSet(redisKey, value, tsExpire);
        }

        private void btnGetKey_Click(object sender, EventArgs e)
        {
            string key = txtKey.Text;

            string errorMessage = null;
            bool isValid = IsValid(key, out errorMessage);
            if (!isValid)
            {
                MessageBox.Show(errorMessage);
                return;
            }

            string redisKey = GetRedisKey(REDIS_KEY_PREFIX, key);
            string value = redis_db.StringGet(redisKey);

            txtValue.Text = value;
        }

        private void btnDeleteKey_Click(object sender, EventArgs e)
        {
            string key = txtKey.Text;

            string errorMessage = null;
            bool isValid = IsValid(key, out errorMessage);
            if (!isValid)
            {
                MessageBox.Show(errorMessage);
                return;
            }

            string redisKey = GetRedisKey(REDIS_KEY_PREFIX, key);
            bool redisResult = redis_db.KeyDelete(redisKey);
        }

        private string GetRedisKey(string keyPrefix, string keyName)
        {
            return REDIS_KEY_PREFIX + keyName;
        }

        private bool IsValid(string text, out string errorMessage)
        {
            errorMessage = null;
            if (String.IsNullOrWhiteSpace(text))
            {
                errorMessage = "Empty string.";
                return false;
            }

            return true;
        }
    }
}
