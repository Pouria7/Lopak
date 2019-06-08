import config from 'react-global-configuration';

export default function conf() { 
    console.log('act');
    config.set({ 
        apiUrl: 'http://localhost:4000',
        a :'w'
    });   
    config.serialize();  
}
