import React, { useEffect, useState } from 'react';
import axios from 'axios';

const App = () => {

    const [sections, setSections] = useState([]);

    useEffect(() => {
        getSections();
    }, []);

    const getSections = async () => {
        const response = await axios.get('/api/scraper/scrape');
        setSections(response.data);
    }

    return (
        <div className='container'>
            <div className="col-md-offset-20 col-md-10">
                {sections.map(section => {
                    return <div key={section.title} className="col-md-offset-3 col-md-6">
                        <div className="section-header">
                            <h2 data-animation="bounceInUp" className="section-heading animated">
                                {section.title}
                            </h2>
                            <p style={{ fontSize: 20 }}>
                                {section.text}
                            </p>
                        </div>
                    </div>

                })}
            </div >
        </div>
    )
}

export default App;