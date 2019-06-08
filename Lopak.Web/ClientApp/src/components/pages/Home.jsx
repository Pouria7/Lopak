import React from 'react';
import { connect } from 'react-redux';


const Home = props => (
<div>
  <section id="M-Section1">
    <div className="row my-5 pt-5 mx-1">
      <div className="col my-3">
        <h1 className="display-4 text-center">لوپـاک چند کلیک تا پـاکی شهر</h1>
      </div>
      <div className="w-100" />
      <div className="col my-3">
        <h6 className="text-center">جهت سهولت در خدمات به مشتریان حتما ثبت نام کنید و از همه خدمات استفاده نمایید.</h6>
      </div>
      <div className="w-100" />
      <div className="mx-auto mt-3">
        <a className="btn btn-success btn-lg lo-btn lo-btn-green fix-w-1 mx-sm-2 ml-5 text-white" href="/Register/SignUp/Create">ثبت نام</a>
        <button type="button" className="btn btn-outline-success btn-lg lo-btn lo-btn-tdark fix-w-1 float-sm-right mx-sm-2 ml-5"> دانلود اپلیکیشن</button>
      </div>
    </div>
  </section>
  <section id="M-Section2">
    <div className="row">
      <div className="card-group mx-auto">
        <div className="card m-3 card-hover-mo" style={{width: '20rem'}}>
          <img src="/assets/home/s2-i1.png" className="card-img-top" alt="..." />
          <div className="card-body">
            <h5 className="card-title text-center pb-3">صرفه جویی در زمان</h5>
            <p className="card-text text-justify">
              شما با استفاده از لوپاک دیگر لازم نیست زمان زیادی را تا رفتن به غرفه های بازیافت صرف کنید با ثبت در خواست در اپ لوپاک راننده ما در محل اقلام بازیافتی شما رو تحویل می گیرد.
            </p>
          </div>
        </div>
        <div className="card m-3 card-hover-mo" style={{width: '20rem'}}>
          <img src="/assets/home/s2-i2.png" className="card-img-top" alt="..." />
          <div className="card-body">
            <h5 className="card-title text-center pb-3">حفظ منابع طبیعی</h5>
            <p className="card-text text-justify">
              منابع طبیعی و معادن کشور ما محدود هستند واصراف این منابع نسل های بعد را از نیازهایشان محروم می سازد. بازیافت این موادو کاربرد مجددآن نه تنها باعث کاهش قیمت تمام شده مواد اولیه می گردد بلکه با کاهش مصرف انرژی باعث جلوگیری از آلودگی می شود.
            </p>
          </div>
        </div>
        <div className="card m-3 card-hover-mo" style={{width: '20rem'}}>
          <img src="/assets/home/s2-i3.png" className="card-img-top" alt="..." />
          <div className="card-body">
            <h5 className="card-title text-center pb-3">درآمد زایی</h5>
            <p className="card-text text-justify">
              در لوپاک شما میتوانید از پسماند خود کسب در آمد کیندفقط کافی است در اپلیکیشن لوپاک درخواست لوپاک باکس کنید و آن را با پسماندخشک پر کنید سپس تحویل دهید
            </p>
          </div>
        </div>
      </div>
    </div>
  </section>
  <section id="M-Section3">
    <div className="row mt-3">
      <div className="col-md-8 order-1 order-md-0" id="sec3-inside">
        <div className="row">
          <div className="col-md-9 offset-md-1">
            <div className="row">
              <div className="col-6">
                <div className="lo-box-feature float-left">
                  <img alt="save" src="/assets/home/s3-i1.png" />
                  <h6 className="text-center">صرفه جویی در زمان</h6>
                </div>
              </div>
              <div className="col-6">
                <div className="lo-box-feature lo-float-b">
                  <img alt="recycle"  src="/assets/home/s3-i2.png" />
                  <h6 className="text-center">کمک به چرخه بازیافت</h6>
                </div>
              </div>
              <div className="col-6">
                <div className="lo-box-feature float-left">
                  <img alt="gift" src="/assets/home/s3-i3.png" />
                  <h6 className="text-center">دریافت جوایزو هدایا</h6>
                </div>
              </div>
              <div className="col-6">
                <div className="lo-box-feature lo-float-b">
                  <img alt="income" src="/assets/home/s3-i4.png" />
                  <h6 className="text-center">درآمدزایی برای کاربران</h6>
                </div>
              </div>
              <div className="col-6">
                <div className="lo-box-feature float-left">
                  <img alt="help" src="/assets/home/s3-i5.png" />
                  <h6 className="text-center">کمک به محیط زیست</h6>
                </div>
              </div>
              <div className="col-6">
                <div className="lo-box-feature lo-float-b">
                  <img alt="" src="/assets/home/s3-i6.png" />
                  <h6 className="text-center">فرهنگ سازی بازیافت</h6>
                </div>
              </div>
              <div className="col-6">
                <div className="lo-box-feature float-left">
                  <img alt="" src="/assets/home/s3-i7.png" />
                  <h6 className="text-center">دسترسی سریع و آسان</h6>
                </div>
              </div>
            </div>
          </div>
          <div className="background" />
        </div>
      </div>
      <div className="col-md-4 pb-2 order-0 rder-md-1">
        <div className="row h-100">
          <div className="col-12 my-auto">
            <h3 className="align-middle text-center text-sm-right">
              ویژگی <span style={{borderTop: 'black solid 2px'}}>های</span> لوپاک
            </h3>
          </div>
        </div>
      </div>
    </div>
  </section>
</div>

);

export default connect()(Home);
