import React from 'react';
import { Container} from 'reactstrap';



export default class HomeFooter extends React.Component {
    constructor (props) {
      super(props);
  
    }
    render () {
        return (
<div>
  <div className="footer-dg" id="circle-d" />
  <Container fluid className="footer-container text-white">
    <div className="row">
      <div className="col-lg-3 col-12">
      </div>
      <div className="col-lg-2 col-6">
        <ul className="flex-column lo-footer-link">
          <li>
            <a   href="">همکاری با ما</a>
          </li>
{/*           <li>
            <a className tag={Link} to="/" href="">باشگاه مشتریان</a>
          </li> */}
          <li>
            <a  href="">سوالات متداول</a>
          </li>
          <li>
            <a href="">قوانین و مقررات</a>
          </li>
        </ul>
      </div>
      <div className="col-lg-2 col-6">
        <ul className="flex-column lo-footer-link">
          <li>
            <a  href="">راهنمای پرداخت و خرید</a>
          </li>
          <li>
            <a  href="">قوانین استراتژیک</a>
          </li>
          <li>
            <a href="">قوانین رانندگان</a>
          </li>
          <li>
            <a href="">نقشه سایت</a>
          </li>
        </ul>
      </div>
      <div className="col-lg-2 col-sm-8 col-12">
        <ul className="flex-column lo-footer-link lo-li-orange">
          <li>
            <a  href="">حریم خصوصی</a>
          </li>
          <li>
            <a href="">درباره ما</a>
          </li>
          <li>
            <a href="">تماس با ما</a>
          </li>
          <li>
            <a  href="">وبلاگ</a>
          </li>
        </ul>
      </div>
      <div className="col-lg-3 col-sm-8 col-12">
      </div>
    </div>
    <div className="row"><hr /></div>
    <div className="row">
      <div className="col">
        <p className="copyright-fa">تمامی حقوق این وبسایت برای شرکت فیدار پاکان پرداز نسیم محفوظ است.</p>
      </div>
      <div className="col">
        <p className="copyright-en">Copyright 2018 lopak.ir</p>
      </div>
    </div>
  </Container>
</div>


        );
    
    }


}

