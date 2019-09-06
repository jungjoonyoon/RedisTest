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
        readonly string REDIS_KEY_PREFIX;
        readonly TimeSpan TS_EXPIRE;
        IDatabase redis_db;              

        private void InitComponents()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(ConfigurationManager.AppSettings["RedisConnectionString"]);
            redis_db = redis.GetDatabase();
        }

        public Form1()
        {
            InitializeComponent();

            try
            {
                REDIS_KEY_PREFIX = ConfigurationManager.AppSettings["RedisKeyPrefix"];
                int redisKeyDaysExpire = int.Parse(ConfigurationManager.AppSettings["RedisKeyDaysExpire"]);
                TS_EXPIRE = TimeSpan.FromDays(redisKeyDaysExpire);

                InitComponents();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.ToString());
            }
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
            try
            {
                string key = txtKey.Text;
                string value = txtValue.Text;

                bool isValid = IsValidWithMessage(key);
                if (!isValid)
                {
                    return;
                }

                string redisKey = GetRedisKey(key);
                bool redisResult = redis_db.StringSet(redisKey, value, TS_EXPIRE);

                ShowMessage(redisResult);
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.ToString());
            }
        }

        private void btnGetKey_Click(object sender, EventArgs e)
        {
            try
            {
                string key = txtKey.Text;

                bool isValid = IsValidWithMessage(key);
                if (!isValid)
                {
                    return;
                }

                string redisKey = GetRedisKey(key);
                string value = redis_db.StringGet(redisKey);

                txtValue.Text = value;
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.ToString());
            }           
        }

        private void btnDeleteKey_Click(object sender, EventArgs e)
        {
            try
            {
                string key = txtKey.Text;

                bool isValid = IsValidWithMessage(key);
                if (!isValid)
                {
                    return;
                }

                string redisKey = GetRedisKey(key);
                bool redisResult = redis_db.KeyDelete(redisKey);

                ShowMessage(redisResult);
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.ToString());
            }            
        }

        private string GetRedisKey(string keyName)
        {
            return $"{REDIS_KEY_PREFIX}:{keyName}";
        }

        private bool IsValidWithMessage(string text)
        {
            bool isValid = true;
            string errorMessage = null;            

            if (String.IsNullOrWhiteSpace(text))
            {
                errorMessage = "Empty string.";
                isValid = false;
            }

            if (!isValid)
            {
                MessageBox.Show(errorMessage);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ShowMessage(bool redisResult)
        {
            MessageBox.Show(redisResult ? "Ok." : "Error.");
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show($"Exception:{Environment.NewLine}{message}");
        }
    }
}
